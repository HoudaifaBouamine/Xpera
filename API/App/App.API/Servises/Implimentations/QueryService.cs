using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Servises.Interfaces;
using App.Models.Dtos.Post.Query;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;
using Dapper;
using System.Data.SqlClient;

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

        public Task<UserReadDto?> LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get All posts in the system
        /// </summary>
        /// <returns>List of PostReadFullDto</returns>
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

        public Task<PostReadFullDto?> ReadPostAsync(int post_id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tag_id)
        {
            throw new NotImplementedException();
        }

        public Task<UserReadDto?> ReadUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostReadFullDto>> ReadUserPostsAsync(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
