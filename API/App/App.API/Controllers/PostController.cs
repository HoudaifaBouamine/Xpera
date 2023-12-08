using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.Interfaces;
using App.API.Servises.Interfaces;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ICommandService _commandService;
        private readonly IQueryService _queryService;
        public PostController(ICommandService commandService,IQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }


        [HttpGet("{id}")]
        private async Task<ActionResult<PostReadFullDto>> GetPost(int id)
        {
            return NotFound( new NotImplementedException() );
        }

        [HttpGet("User_Id/{user_Id}")]
        private async Task<ActionResult<IEnumerable<PostReadFullDto>>> GetUserPosts(int user_Id)
        {
            return NotFound(new NotImplementedException());

        }

        [HttpGet("tag/{tag}")]

        private async Task<ActionResult<IEnumerable<PostReadFullDto>>> GetTagPosts(int tag_Id)
        {
            return NotFound(new NotImplementedException());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostReadFullDto>>> GetAllPosts()
        {
            return Ok( await _queryService.ReadAllPostsAsync() );
        }

        [HttpPost]

        public async Task<ActionResult<PostReadMinimulDto>> CreateNewPost([FromBody] PostCreateDto postCreate)
        {
            return Ok( await _commandService.CreatePost(postCreate) );
        }
    }
}
