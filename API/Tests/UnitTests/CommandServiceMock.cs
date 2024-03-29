using App.API.Extentions.DtosExtentions;
using App.API.Models;
using App.API.Models.PostModels;
using App.API.Services.Interfaces;
using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;

namespace App.Tests.Mocks;
public class CommandServiceMock(List<PostModel> postsList) : ICommandService 
{

    List<PostModel> _postsList = postsList;
    int currentId = 1;
    public async Task<PostReadMinimulDto?> PostCreateAsync(PostCreateDto postToCreate, UserModel user)
    {
        var post = postToCreate.ToEntity();
        post.Post_Id = currentId++;
        post.User_Id = user.User_Id;
        post.User = user;
        _postsList.Add(post);

        var postMinDto = new PostReadMinimulDto
        {
            Post_Id = post.Post_Id,
            User_Id = post.User_Id,
            Title = post.Title,
            Body = post.Body,
            PublishDateTime = post.PublishDateTime,
            Tags = [],
            CommentsNumber = post.CommentsNumber,
            FavoritsNumber = post.NumberOfLikes
        };

        return postMinDto;
    }




    public Task<CommentMinReadDto> CreateCommentAsync(CommentCreateDto comment)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCommentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PostDeleteAsync(int postToDelete_id)
    {
        throw new NotImplementedException();
    }

    public Task<PostReadMinimulDto?> PostUpdateAsync(PostUpdateDto postToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task UserDeleteAsync(Guid UserToDelete_id)
    {
        throw new NotImplementedException();
    }

    public Task<UserReadDto?> UserFirebaseRegisterAsync(UserFirebaseCreateDto userToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<UserReadDto?> UserRegisterAsync(UserCreateDto userToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserUpdateAsync(UserUpdateDto userToUpdate)
    {
        throw new NotImplementedException();
    }
}
