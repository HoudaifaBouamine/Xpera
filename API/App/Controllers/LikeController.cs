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
    public class FavoritController(IQueryService queryService,AppDbContext db) : ControllerBase
    {
        AppDbContext db = db;
        IQueryService _queryService = queryService;

        /// <summary>
        /// Get the number of favorits in the post
        /// </summary>
        /// <param name="post_id"></param>
        /// <returns></returns>
        [HttpGet("/api/post/{post_id}/favorits")]
        public async Task<ActionResult<object>> Get(int post_id)
        {
            
            PostModel? post = db.Posts
                    .Include(p=>p.UsersWhoLikedThisPost)
                    .FirstOrDefault(p=>p.Post_Id == post_id);
                    
            if(post is null)
                return NotFound();

            post.NumberOfLikes = post.UsersWhoLikedThisPost.Count();

            var postDto = post.ToDto();

            return Ok(new { FavoritsNumber = post.UsersWhoLikedThisPost.Count()});
        }

        /// <summary>
        /// Add favorit to the post by the user (user identified by cookie)
        /// if user allready added favorit to the post, the like will be removed
        /// </summary>
        /// <param name="post_id"></param>
        /// <returns></returns>
        [HttpPost("/api/post/{post_id}/favorits")]
    
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
            {
                postModel.UsersWhoLikedThisPost.Remove(user);
                postModel.NumberOfLikes--;
            }
            else
            {
                postModel.UsersWhoLikedThisPost.Add(user);
                postModel.NumberOfLikes++;
            }

            db.SaveChanges();

            return Ok();
            
        }

    }
}
