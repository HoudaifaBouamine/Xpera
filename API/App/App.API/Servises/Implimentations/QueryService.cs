using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Servises.Interfaces;
using App.Models.Dtos.Post;
using App.Models.Dtos.Post.Query;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.API.Servises.Implimentations
{
    public class QueryService : IQueryService
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionStringName = "DefaultConnection";

        List<Tag> Tags = null!;

        public QueryService(IConfiguration configuration)
        {
            _configuration = configuration;

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            Tags = connection.Query<Tag>($"SELECT * FROM Tags").ToList();
        }

        // Done
        public async Task<UserReadDto?> LoginUser(string email, string password)
        {
            string query = $"SELECT * FROM Users u WHERE u.Email = @UserEmail";

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            User? user = await connection.QueryFirstOrDefaultAsync<User?>
                (
                    query,
                    param:new { UserEmail = email}
                );

            if(user == null)
            {
                return null;
            }

            if(user.HashedPassword != _HashPassword( password ))
            {
                return null;
            }

            return user.ToDto();
        }

        private string _HashPassword(string password)
        {
            return password;
        }

        // Done
        public async Task<IEnumerable<PostReadFullDto>> ReadAllPostsAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            List< PostHaveTagDto> postHaveTagDtos = (await connection.QueryAsync<PostHaveTag,Tag,PostHaveTagDto>(
                $"SELECT pht.PostHaveTag_Id,pht.Post_Id,t.* FROM PostsHaveTags pht JOIN Tags t ON pht.Tag_Id = t.Tag_Id",
                (postHaveTag,tag) => 
                {
                    postHaveTag.Tag_Id = tag.Tag_Id;
                    return postHaveTag.ToDto(tag);
                },
                splitOn:"Tag_Id")).ToList();

            return await connection.QueryAsync<Post, User, PostReadFullDto>(
                $"SELECT p.Post_Id,p.Title,p.Body,p.PublishDateTime, u.* FROM Posts p JOIN Users u ON p.User_Id = u.User_Id;",
                (post, user) =>
                {
                    post.User_Id = user.User_Id;
                    return post.ToDto(user, (postHaveTagDtos.Where(phtd => phtd.Post_Id == post.Post_Id)).ToEntities().ToList() );
                    
                },
                splitOn:"User_Id");
        }

        // Done
        public async Task<PostReadFullDto?> ReadPostAsync(int post_id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            string query = $"SELECT p.*,1 as Sep,u.* FROM Posts p JOIN Users u ON p.User_Id = u.User_Id WHERE p.Post_Id = @Post_Id";

            PostReadFullDto postReadFullDto = (await connection.QueryAsync<PostReadFullDto,User,PostReadFullDto>
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

            var tags = await _GetTagsByPosts(new List<int>(){ postReadFullDto.Post_Id });

            postReadFullDto.Tags = tags.ToEntities().ToDto();

            return postReadFullDto;

        }


        // Done
        public async Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tag_id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            
            // Get Post With The Publisher (User)
            string postsQuery = 
                $"SELECT p.*,1 as Sep,u.* " +
                $"FROM Posts p  " +
                $"JOIN PostsHaveTags pht  " +
                $"ON p.Post_Id = pht.Post_Id  " +
                $"JOIN Tags t  " +
                $"ON t.Tag_Id = pht.Tag_Id " +
                $"JOIN Users u  " +
                $"ON u.User_Id = p.User_Id " +
                $"Where t.tag_id = @Tag_id";


            List<PostReadFullDto> posts = (await connection.QueryAsync<Post,User,PostReadFullDto>(
                postsQuery,
                (post,user) =>
                {
                    return post.ToDto(user, new List<Tag>());
                },
                param: new { Tag_id = tag_id },
                splitOn:"Sep"
                )).ToList();


            List<PostHaveTagDto> tags = await _GetTagsByPosts(from p in posts select p.Post_Id);

            for(int i = 0; i < posts.Count(); i++)
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

        // Done
        private async Task<List<PostHaveTagDto>> _GetTagsByPosts(IEnumerable<int> posts_ids)
        {

            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            string tagsQuery =
                $"SELECT pht.*,1 as Sep,t.* " +
                $"FROM PostsHaveTags pht " +
                $"JOIN Tags t " +
            $"ON pht.Tag_Id = t.Tag_Id " +
            $"WHERE pht.Post_Id in @Posts_ids";

            List<PostHaveTagDto> tags = (await connection.QueryAsync<PostHaveTag, Tag, PostHaveTagDto>(
                tagsQuery,
                (postHaveTag, tag) =>
                {
                    return postHaveTag.ToDto(tag);
                },
                param: new { Posts_ids = posts_ids },
                splitOn: "Sep")).ToList();

            return tags;
        }

        public Task<UserReadDto?> ReadUser(int user_id)
        {
            throw new NotImplementedException();
        }

        // Done
        public async Task<IEnumerable<PostReadMinimulDto>> ReadUserPostsAsync(int user_id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

            string query = $"SELECT * FROM Posts p WHERE p.User_Id = @User_Id";

            IEnumerable<Post> posts = await connection.QueryAsync<Post>(
                query,
                param: new { User_Id = user_id }
                );

            IEnumerable<PostHaveTagDto> tags = await _GetTagsByPosts(from p in posts select p.Post_Id);

            var result = posts.ToMinDto(tags);

            return result;
        }

    }
}
