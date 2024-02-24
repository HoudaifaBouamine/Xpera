using App.API.AuthenticationService;
using App.API.Data;
using App.API.Extentions.DtosExtentions;
using App.API.Models;
using App.API.Models.PostModels;
using App.API.Services.Interfaces;
using App.Models.Dtos.User.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Namespace
{
    [Route("api/post/[controller]")]
    [ApiController]
    public class LikeController(IQueryService queryService,AppDbContext db) : ControllerBase
    {
        AppDbContext db = db;
        IQueryService _queryService = queryService;

        [HttpGet("/api/post/{post_id}/likes")]
        public async Task<ActionResult<object>> Get(int post_id)
        {
            
            PostModel? post = db.Posts
                    .Include(p=>p.UsersWhoLikedThisPost)
                    .FirstOrDefault(p=>p.Post_Id == post_id);
                    
            if(post is null)
                return NotFound();

            post.NumberOfLikes = post.UsersWhoLikedThisPost.Count();

            var postDto = post.ToDto();

            return Ok(post.UsersWhoLikedThisPost.Count());
        }

        [HttpPost("/api/post/{post_id}/likes")]
        public async Task<ActionResult> Post(int post_id)
        {

            string? id_as_string = User.Claims
                .FirstOrDefault
                    (c=>c.Type == Auth.UserClaims.Id)?.Value ;

            if(id_as_string is null)
            {
                return NotFound();
            }

            UserModel? user = db.Users.FirstOrDefault(u=>u.User_Id == Guid.Parse(id_as_string));
                    
            PostModel? postModel = db.Posts
                .Include(p=>p.UsersWhoLikedThisPost)
                .FirstOrDefault(p=>p.Post_Id == post_id);
            
            if(user is null || postModel is null)
                return NotFound();

            if(postModel.UsersWhoLikedThisPost.Contains(user))
                return BadRequest("--> Error : user allready liked this post");
            
            postModel.UsersWhoLikedThisPost.Add(user);

            postModel.NumberOfLikes++;

            db.SaveChanges();

            return Ok();
            
        }

    }
}
