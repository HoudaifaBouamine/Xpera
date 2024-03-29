using System.Security.Claims;
using System.Windows.Input;
using App.API.AuthenticationService;
using App.API.Controllers;
using App.API.Data;
using App.API.Models;
using App.API.Models.PostModels;
using App.API.Services.Interfaces;
using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;
using App.Tests.Mocks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace App.Tests.PostsFeatures;

public class PostsFeaturesTests
{
    public string? AuthSchem { get; private set; }

    [Fact]
    public async void TestEmptyListWhenNoPosts()
    {
        // arrange
        List<PostModel> postsList = [];
        CommandServiceMock commandServiceMock = new(postsList);
        QueryServiceMock queryServiceMock = new(postsList);
        PostController postController = new PostController(commandServiceMock,queryServiceMock,new AppDbContext(new ConfigurationBuilder().Build()));
        
        // act
        var response = await postController.GetAllPosts();
        var result = response.Result as OkObjectResult;
        var posts = result?.Value as IEnumerable<PostReadFullDto>;
        
        // assert
        Assert.NotNull(result);
        Assert.NotNull(posts);
        Assert.Empty(posts);
    }

    [Fact]
    public async Task TestReadingAllPostsWhenThereIsPosts()
    {

        // arrange
        List<PostModel> postsList = [];

        var user = new UserModel
        {
            User_Id = Guid.NewGuid(),
            Email = "email",
            FirstName = "firstName",
            LastName = "lastName",
            HashedPassword = "hashedPassword"
        };

        var post1 = new PostModel
        {
            Post_Id = 1,
            Body = "body1",
            CommentsNumber = 0,
            NumberOfLikes = 0,
            PostTags = [],
            PublishDateTime = DateTime.UtcNow.AddDays(-5),
            Title = "title1",
            User_Id = user.User_Id,
            User = user,
            UsersWhoLikedThisPost = []
        };

        var post2 = new PostModel
        {
            Post_Id = 2,
            Body = "body2",
            CommentsNumber = 0,
            NumberOfLikes = 0,
            PostTags = [],
            PublishDateTime = DateTime.UtcNow.AddDays(-4),
            Title = "title2",
            User_Id = user.User_Id,
            User = user,
            UsersWhoLikedThisPost = []
        };

        postsList.Add(post1);
        postsList.Add(post2);
        CommandServiceMock commandServiceMock = new(postsList);
        QueryServiceMock queryServiceMock = new(postsList);
        PostController postController = new PostController(commandServiceMock,queryServiceMock,new AppDbContext(new ConfigurationBuilder().Build()));
        
        // act
        var response = await postController.GetAllPosts();
        var result = response.Result as OkObjectResult;
        var posts = result?.Value as IEnumerable<PostReadFullDto>;
        
        // assert
        Assert.NotNull(result);
        Assert.NotNull(posts);
        Assert.Equal(2,posts.Count());
        Assert.Equal(post1.Title,posts.FirstOrDefault(p=>p.Post_Id == post1.Post_Id)!.Title);
        // Assert.Equal(post2.Title,posts.FirstOrDefault(p=>p.Post_Id == post2.Post_Id)!.Title);
    }

    [Fact]
    public async Task TestCreatingPostsThenReadingAllPosts()
    {

        // arrange
        List<PostModel> postsList = [];

        var user = new UserModel
        {
            User_Id = Guid.NewGuid(),
            Email = "email",
            FirstName = "firstName",
            LastName = "lastName",
            HashedPassword = "hashedPassword"
        };

        var post1 = new PostModel
        {
            Post_Id = 1,
            Body = "body1",
            CommentsNumber = 0,
            NumberOfLikes = 0,
            PostTags = [],
            PublishDateTime = DateTime.UtcNow.AddDays(-5),
            Title = "title1",
            User_Id = user.User_Id,
            User = user,
            UsersWhoLikedThisPost = []
        };

        CommandServiceMock commandServiceMock = new(postsList);
        QueryServiceMock queryServiceMock = new(postsList);
        PostController postController = new PostController(commandServiceMock,queryServiceMock,new AppDbContext(new ConfigurationBuilder().Build()));
        
        // await postController.HttpContext.SignInAsync(Auth.Scheme.UserCookie, _authService.CreateUserClaimsPrincipal(user, Auth.Scheme.UserCookie));
            
            List<Claim> claims = new List<Claim>
            {
                new (Auth.UserClaims.Id          ,user.User_Id.ToString()),
                new (Auth.UserClaims.FirstName   ,user.FirstName),
                new (Auth.UserClaims.LastName    ,user.LastName),
                new (Auth.UserClaims.Email       ,user.Email),
            };
            ClaimsIdentity claimsIdentity = new(claims, AuthSchem);
        System.Console.WriteLine("\n----- wow 0 ------\n");

        // postController.User.AddIdentity(claimsIdentity);
        Assert.Null(postController.User);
                System.Console.WriteLine("\n----- wow 1 ------\n");

        // act
        var response = await postController.CreateNewPost(new PostCreateDto
        {
            Body = post1.Body,
            TagsNames = [],
            Title = post1.Title,
        });
        System.Console.WriteLine("\n----- wow 1-1 ------\n");
        var result = response.Result as OkObjectResult;
        var postResult = result?.Value as PostReadMinimulDto;
        System.Console.WriteLine("\n----- wow 2 ------\n");
        // assert
        Assert.NotNull(result);
        Assert.NotNull(postResult);
        Assert.Equal(post1.Title,postResult.Title);
        Assert.Equal(post1.Post_Id,postResult.Post_Id);
        Assert.Equal(post1.User_Id,postResult.User_Id);
        // Assert.Equal(post2.Title,posts.FirstOrDefault(p=>p.Post_Id == post2.Post_Id)!.Title);
    }

}