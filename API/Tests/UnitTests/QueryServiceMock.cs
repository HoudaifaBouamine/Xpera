using App.API.Extentions.DtosExtentions;
using App.API.Models.PostModels;
using App.API.Services.Interfaces;
using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;
using App.Tests.Mocks;
using Microsoft.EntityFrameworkCore.Metadata;

class QueryServiceMock (List<PostModel> postList) : IQueryService
{

    List<PostModel> _postList = postList;
    public async Task<IEnumerable<PostReadFullDto>> ReadAllPostsAsync()
    {
        return _postList.ToDtoList(null,null);
    }




    public Task<UserReadDto?> LoginUser(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CommentUserReadDto>> ReadCommentsByPostIdAsync(int post_id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CommentPostReadDto>> ReadCommentsByUserIdAsync(Guid user_id)
    {
        throw new NotImplementedException();
    }

    public Task<PostReadFullDto?> ReadPostAsync(int post_id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tag_id)
    {
        throw new NotImplementedException();
    }

    public Task<UserReadDto?> ReadUserAsync(Guid user_id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostReadMinimulDto>> ReadUserPostsAsync(Guid user_id)
    {
        throw new NotImplementedException();
    }
}
