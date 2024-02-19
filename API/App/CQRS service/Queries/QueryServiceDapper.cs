using App.API.Extentions.DtosExtentions;
using App.API.Models;
using App.API.Models.Post_Models.Comment_Models;
using App.API.Models.PostModels;
using App.API.Security;
using App.API.Services.Interfaces;
using App.Models.Dtos.Comment;
using App.Models.Dtos.Post;
using App.Models.Dtos.Post.Query;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace App.API.Servises.Implimentations
{
    public class QueryServiceDapper : IQueryService
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionStringName = "DefaultConnection";

        List<TagModel> Tags = null!;

        public QueryServiceDapper(IConfiguration configuration)
        {
            _configuration = configuration;

            // using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            // Tags = connection.Query<TagModel>($"SELECT * FROM Tags").ToList();
        }


        #region User
        public async Task<UserReadDto?> LoginUser(string email, string password)
        {
            string query = $"EXEC GetUserByEmail @UserEmail = @Email";

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            UserModel? user = await connection.QueryFirstOrDefaultAsync<UserModel?>
                (
                    query,
                    param:new { Email = email}
                );

            if(user == null)
            {
                return null;
            }

            if(! SecurityService.VerifyPassword(user.HashedPassword,password))
            {
                return null;
            }

            return user.ToDto();
        }

        public async Task<UserReadDto?> ReadUserAsync(Guid user_id)
        {
            string query = $"SELECT * FROM Users u WHERE u.User_Id = @User_Id";

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            UserModel? user = await connection.QueryFirstOrDefaultAsync<UserModel?>
                (
                    query,
                    param: new { User_Id = user_id }
                );

            if (user == null)
            {
                return null;
            }

            return user.ToDto();
        }

        #endregion


        #region Post
        public async Task<IEnumerable<PostReadFullDto>> ReadAllPostsAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            List<PostHaveTagDto> postHaveTagDtos = (await connection.QueryAsync<PostHaveTagRelation, TagModel, PostHaveTagDto>(
                "exec GetPostsHaveTags",
                (postHaveTag,tag) => 
                {
                    postHaveTag.Tag_Id = tag.Tag_Id;
                    return postHaveTag.ToDto(tag);
                },
                splitOn:"Tag_Id")).ToList();

            return await connection.QueryAsync<PostModel, UserModel, PostReadFullDto>(
                "exec GetPostsAndUsers",
                (post, user) =>
                {
                    post.User_Id = user.User_Id;
                    return post.ToDto(user, (postHaveTagDtos.Where(phtd => phtd.Post_Id == post.Post_Id)).ToEntities().ToList() );
                    
                },
                splitOn:"User_Id");
        }
        public async Task<PostReadFullDto?> ReadPostAsync(int post_id)
        {
            if (post_id <= 0) return null;

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            string query = $"exec GetPostById @Post_Id = {post_id}";

            PostReadFullDto postReadFullDto = (await connection.QueryAsync<PostReadFullDto,UserModel,PostReadFullDto>
                (
                    query,
                    (postDto,user) =>
                    {
                        postDto.User = user.ToDto();
                        return postDto;
                    },
                    param: new { Post_Id = post_id },
                    splitOn:"Sep"
                )).FirstOrDefault()!;
            
            if(postReadFullDto == null)
            {
                return null;
            }

            var tags = await _GetTagsByPosts(new List<int>(){ postReadFullDto.Post_Id });

            postReadFullDto.Tags = tags.ToEntities().ToDto();

            return postReadFullDto;

        }
        public async Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tag_id)
        {
            if(tag_id <= 0)
            {
                return Enumerable.Empty<PostReadFullDto>();
            }

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            // Get Post With The Publisher (User)
            string postsQuery = $"EXEC GetPostsByTag @Tag_id = {tag_id}";

            List<PostReadFullDto> posts = (await connection.QueryAsync<PostModel,UserModel,PostReadFullDto>(
                postsQuery,
                (post,user) =>
                {
                    return post.ToDto(user, new List<TagModel>());
                },
                param: new { Tag_id = tag_id },
                splitOn:"Sep"
                )).ToList();


            IEnumerable<PostHaveTagDto> tags = await _GetTagsByPosts(from p in posts select p.Post_Id);

            for(int i = 0; i < posts.Count; i++)
            {
                posts[i].Tags = (from t in tags where t.Post_Id == posts[i].Post_Id 
                                 select new TagDto()
                                {
                                     Name = t.Tag_Name,
                                     Tag_Id = t.Tag_Id
                                }).ToList() ;
            }

            return posts;
        }
        private async Task<IEnumerable<PostHaveTagDto>> _GetTagsByPosts(IEnumerable<int> posts_ids)
        {

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            
            var postIdsList = string.Join(",", posts_ids);

            IEnumerable<PostHaveTagDto> tags = (await connection.QueryAsync<PostHaveTagRelation, TagModel, PostHaveTagDto>(
                "GetPostsByPostIds",
                (postHaveTag, tag) =>
                {
                    return postHaveTag.ToDto(tag);
                },
                commandType: CommandType.StoredProcedure,
                param: new { PostIdsList = postIdsList },
                splitOn: "Sep"
            ));

            return tags;
        }
        public async Task<IEnumerable<PostReadMinimulDto>> ReadUserPostsAsync(Guid user_id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            string query = $"SELECT * FROM Posts p WHERE p.User_Id = @User_Id";

            IEnumerable<PostModel> posts = await connection.QueryAsync<PostModel>(
                query,
                param: new { User_Id = user_id }
                );

            IEnumerable<PostHaveTagDto> tags = await _GetTagsByPosts(from p in posts select p.Post_Id);

            var result = posts.ToMinDto(tags);

            return result;
        }

        #endregion

        #region Comment
        public async Task<IEnumerable<CommentPostReadDto>> ReadCommentsByUserIdAsync(Guid user_id)
        {
            var sql = $"exec Get_Comments_With_Posts_By_User_Id @User_Id = {user_id}";

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            var comments = await connection.QueryAsync<CommentModel, PostModel, CommentPostReadDto>(
                sql,
                (comment,post) =>
                {
                    return comment.ToDto(post.ToDto(new(),new()));
                },
                splitOn:"Sep");

            return comments;
        }

        public Task<IEnumerable<CommentUserReadDto>> ReadCommentsByPostIdAsync(int post_id)
        {
            var sql = $"exec Get_Comments_With_Users_By_Post_Id @Post_Id = {post_id}";

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));


            var comments = connection.QueryAsync<CommentModel, UserModel, CommentUserReadDto>(sql,
            (command, user) =>
            {
                return command.ToDto(user);
            });

            return comments;
        }

        #endregion

    }
}
