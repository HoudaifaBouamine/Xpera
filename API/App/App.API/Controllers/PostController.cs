using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.Interfaces;
using App.Models.Dtos.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostController(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PostReadDto>> GetPost(int id)
        {
            var post = await _postRepository.Read(id);
            var tags = await _postRepository.ReadPostTags(id);
            var user = await _userRepository.Read(post!.User_Id);

            var postsAsDto = post.ToDto(user!, tags);

            return postsAsDto;
        }

        [HttpGet("User_Id/{user_Id}")]
        public async Task<ActionResult<IEnumerable<PostReadDto>>> GetUserPosts(int user_Id)
        {
            IEnumerable<Post> posts = await _postRepository.ReadUserPostsAsync(user_Id);

            var tags = new List<List<Tag>>();

            var user = await _userRepository.Read(user_Id);

            if (user == null)
            {
                return NotFound($"User with User_Id = \'{user_Id}\' is not found");
            }

            foreach (var post in posts)
            {
                tags.Add(await _postRepository.ReadPostTags(post.Post_Id));
            }

            var postesAsDto = posts.ToDtoList(user!, tags);

            return Ok(postesAsDto);
        }

    }
}
