using App.API.Entities;
using App.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
            this._userRepository = userRepository;
        }

        [HttpGet("id")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User? user = await _userRepository.Read(id);

            if(user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            User? createdUser = await _userRepository.Create(user);

            if(createdUser == null) return BadRequest("Failed To Create New User");

            return Ok(createdUser);
        }

    }
}
