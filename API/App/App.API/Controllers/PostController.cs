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
    }
}
