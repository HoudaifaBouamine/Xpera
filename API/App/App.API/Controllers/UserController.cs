using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.Interfaces;
using App.Models.Dtos.Post;
using App.Models.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public UserController(IUserRepository userRepository,IPostRepository postRepository) 
        {
            this._userRepository = userRepository;
            this._postRepository = postRepository;
        }

        [HttpGet("id")]
        public async Task<ActionResult<UserReadDto>> Get(int id)
        {
            User? user = await _userRepository.Read(id);

            if(user == null) return NotFound();

            return Ok(user.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserCreateDto user)
        {
            if( await _userRepository.Read(user.Email) != null)
            {
                return BadRequest($"User with email [{user.Email}] is already exist");
            }

            User? createdUser = await _userRepository.Create(user.ToEntity());

            if (createdUser == null)
            {
                return BadRequest("Failed To Create New User");
            }

            return Ok(createdUser);
        }


    }
}
