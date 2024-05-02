using App.API.AuthenticationService;
using App.API.Data;
using App.API.Extentions.DtosExtentions;
using App.API.Models.PostModels;
using App.API.Services.Interfaces;
using App.Models.Dtos.Post;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(ICommandService commandService, IQueryService queryService,AppDbContext db) : ControllerBase
    {
        private readonly ICommandService _commandService = commandService;
        private readonly IQueryService _queryService = queryService;

        // Refactor
        private readonly AppDbContext db = db;
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<PostReadMinimulDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok( await _queryService.ReadAllPostsAsync() );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(PostReadFullDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<IActionResult> GetPost(int id)
        {
            PostReadFullDto? post = await _queryService.ReadPostAsync(id);
            if(post == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(post);
            }
        }

        [HttpGet("User_Id/{user_Id}")]
        public async Task<ActionResult<IEnumerable<PostReadFullDto>>> GetUserPosts(Guid user_Id)
        {
            return Ok( await _queryService.ReadUserPostsAsync(user_Id) );

        }

        [HttpGet("tag/{tag_Id}")]
        public async Task<ActionResult<IEnumerable<PostReadFullDto>>> GetTagPosts(int tag_Id)
        {
            return Ok(  await _queryService.ReadTagPostsAsync(tag_Id) );
        }


        [HttpPost]
        [Authorize(Policy =Auth.Policy.RequireUser)]
        
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(PostReadMinimulDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNewPost([FromBody] PostCreateDto postCreate)
        {
            string? id_as_string = User.Claims.FirstOrDefault(c=>c.Type == Auth.UserClaims.Id)?.Value ;

            if(id_as_string is null)
            {
                return Unauthorized();
            }

            var user = await _queryService.ReadUserAsync(Guid.Parse(id_as_string));
            
            if(user is null)
                return NotFound();

            return Ok( await _commandService.PostCreateAsync(postCreate,user.ToEntity() ));
        }

        [HttpDelete("{post_id}")]
        [Authorize(Policy = Auth.Policy.RequireUser)]
        public async Task<ActionResult> DeletePost(int post_id)
        {
            if(await _commandService.PostDeleteAsync(post_id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("/api/tag/{tag_id}")]
        public async Task<ActionResult<string?>> GetAllTags(int tag_id){
            return await db.Tags.Where(t=>t.Tag_Id == tag_id).Select(t=>t.ToDto()).FirstOrDefaultAsync();
        }

        [HttpGet("/api/tag")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllTags(){
            return await db.Tags.Select(t=>t.ToDto()).ToListAsync();
        }

        [HttpPost("/api/tag")]
        public async Task<ActionResult<string>> CreateTag([FromBody] TagCreateDto tagCreate)
        {
            // Refactor

            var tag = new TagModel{
                Name = tagCreate.Name
            };

            var entity = db.Tags.Add(tag);

            await db.SaveChangesAsync();

            return tag.ToDto();
        }

    
    }
}
