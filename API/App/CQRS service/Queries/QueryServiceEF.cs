using App.API.Data;
using App.API.Extentions.DtosExtentions;
using App.API.Models;
using App.API.Models.PostModels;
using App.API.Security;
using App.API.Services.Interfaces;
using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace App.API.Servises.Implimentations
{
    public class QueryServiceEF : IQueryService
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionStringName = "DefaultConnection";
        private readonly AppDbContext db;

        List<TagModel> Tags = null!;

        public QueryServiceEF(IConfiguration configuration,AppDbContext db)
        {
            _configuration = configuration;
            this.db = db;
        }


        #region User
        public async Task<UserReadDto?> LoginUser(string email, string password)
        {
            var user = await db.Users.Where(u=>
                u.Email == email
            ).FirstOrDefaultAsync();

            if(user is null){
                return null;
            }

            if(! SecurityService.VerifyPassword(user.HashedPassword ,password)){
                return null;
            }

            return user.ToDto();

        }

        public async Task<UserReadDto?> ReadUserAsync(Guid user_id)
        {
            return (await db.Users.Where(u=>u.User_Id == user_id).FirstOrDefaultAsync())!.ToDto();
        }

        #endregion
        

        #region Post
        public async Task<IEnumerable<PostReadFullDto>> ReadAllPostsAsync()
        {
            var posts = await db.Posts
                .Include(p => p.User)
                .Include(p => p.PostTags)
                    .ThenInclude(pt => pt.Tag)
                .ToListAsync();

            return posts.Select(post =>
            {
                var postDto = post.ToDto();

                postDto.User = post.User.ToDto();

                postDto.Tags = post.PostTags.Select(pt => pt.Tag.ToDto()).ToList();

                return postDto;
            });
        }

        public async Task<PostReadFullDto?> ReadPostAsync(int postId)
        {
            if (postId <= 0)
                return null;

            var post = await db.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Post_Id == postId);

            if (post == null)
                return null;

            var postDto = post.ToDto();
            postDto.User = post.User.ToDto();

            var tags = await db.PostsHaveTags
                .Where(pt => pt.Post_Id == postId)
                .Select(pt => pt.Tag.ToDto())
                .ToListAsync();

            postDto.Tags = tags;

            return postDto;
        }

        // public async Task<PostReadFullDto?> ReadPostAsync(int post_id)
        // {
        //     if (post_id <= 0) return null;

        //     using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
        //     string query = $"exec GetPostById @Post_Id = {post_id}";

        //     PostReadFullDto postReadFullDto = (await connection.QueryAsync<PostReadFullDto,UserModel,PostReadFullDto>
        //         (
        //             query,
        //             (postDto,user) =>
        //             {
        //                 postDto.User = user.ToDto();
        //                 return postDto;
        //             },
        //             param: new { Post_Id = post_id },
        //             splitOn:"Sep"
        //         )).FirstOrDefault()!;
            
        //     if(postReadFullDto == null)
        //     {
        //         return null;
        //     }

        //     var tags = await _GetTagsByPosts(new List<int>(){ postReadFullDto.Post_Id });

        //     postReadFullDto.Tags = tags.ToEntities().ToDto();

        //     return postReadFullDto;

        // }

public async Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tagId)
{
    if (tagId <= 0)
    {
        return Enumerable.Empty<PostReadFullDto>();
    }

    var posts = await db.Posts
        .Include(p => p.User)
        .Where(p => p.PostTags.Any(pt => pt.Tag_Id == tagId))
        .ToListAsync();

    var postIds = posts.Select(p => p.Post_Id).ToList();
    var tags = await db.PostsHaveTags
        .Where(pt => postIds.Contains(pt.Post_Id))
        .ToListAsync();

    var postDtos = posts.Select(post =>
    {
        var postDto = post.ToDto();
        postDto.User = post.User.ToDto();
        postDto.Tags = tags
            .Where(pt => pt.Post_Id == post.Post_Id)
            .Select(pt => pt.Tag.Name)
            .ToList();
        return postDto;
    });

    return postDtos;
}

        // public async Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tag_id)
        // {
        //     if(tag_id <= 0)
        //     {
        //         return Enumerable.Empty<PostReadFullDto>();
        //     }

        //     using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));

        //     // Get Post With The Publisher (User)
        //     string postsQuery = $"EXEC GetPostsByTag @Tag_id = {tag_id}";

        //     List<PostReadFullDto> posts = (await connection.QueryAsync<PostModel,UserModel,PostReadFullDto>(
        //         postsQuery,
        //         (post,user) =>
        //         {
        //             return post.ToDto(user, new List<TagModel>());
        //         },
        //         param: new { Tag_id = tag_id },
        //         splitOn:"Sep"
        //         )).ToList();


        //     IEnumerable<PostHaveTagDto> tags = await _GetTagsByPosts(from p in posts select p.Post_Id);

        //     for(int i = 0; i < posts.Count; i++)
        //     {
        //         posts[i].Tags = (from t in tags where t.Post_Id == posts[i].Post_Id 
        //                          select new TagDto()
        //                         {
        //                              Name = t.Tag_Name,
        //                              Tag_Id = t.Tag_Id
        //                         }).ToList() ;
        //     }

        //     return posts;
        // }
        
        // private async Task<IEnumerable<PostHaveTagDto>> _GetTagsByPosts(IEnumerable<int> posts_ids)
        // {

        //     using var connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
            
        //     var postIdsList = string.Join(",", posts_ids);

        //     IEnumerable<PostHaveTagDto> tags = (await connection.QueryAsync<PostHaveTagRelation, TagModel, PostHaveTagDto>(
        //         "GetPostsByPostIds",
        //         (postHaveTag, tag) =>
        //         {
        //             return postHaveTag.ToDto(tag);
        //         },
        //         commandType: CommandType.StoredProcedure,
        //         param: new { PostIdsList = postIdsList },
        //         splitOn: "Sep"
        //     ));

        //     return tags;
        // }

        public async Task<IEnumerable<PostReadMinimulDto>> ReadUserPostsAsync(Guid userId)
        {
             var posts = await db.Posts
        .Include(p => p.PostTags)
            .ThenInclude(pt => pt.Tag)
        .Where(p => p.User_Id == userId)
        .ToListAsync();

    if (posts == null)
        return Enumerable.Empty<PostReadMinimulDto>();

    var result = posts.Select(post =>
    {
        var postDto = post.ToDto(null);
        
        if (post.PostTags != null)
        {
            postDto.Tags = post.PostTags
                .Select(pt => pt.Tag.Name)
                .ToList();
        }
        
        return postDto;
    });

    return result;
        }

        #endregion

        #region Comment
public async Task<IEnumerable<CommentPostReadDto>> ReadCommentsByUserIdAsync(Guid userId)
{
    var comments = await db.Comments
        .Include(c => c.Post)
        .Where(c => c.User_Id == userId)
        .ToListAsync();

    var commentDtos = comments.Select(comment =>
    {
        var postDto = comment.Post.ToDto(new UserModel(), new List<TagModel>()); // Assuming you have a method to map PostModel to PostDto
        return comment.ToDto(postDto); // Assuming you have a method to map CommentModel to CommentPostReadDto
    });

    return commentDtos;
}

public async Task<IEnumerable<CommentUserReadDto>> ReadCommentsByPostIdAsync(int postId)
{
    var comments = await db.Comments
        .Include(c => c.User)
        .Where(c => c.Post_Id == postId)
        .ToListAsync();

    var commentDtos = comments.Select(comment =>
    {
        return comment.ToDto(comment.User); // Assuming you have a method to map CommentModel to CommentUserReadDto
    });

    return commentDtos;
}


        #endregion

    }
}
