using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.Interfaces;
using App.API.Servises.Interfaces;
using App.Models.Dtos.Post;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly private ICommandService _commandService;
        readonly private IQueryService _queryService;

        public UserController(ICommandService commandService,IQueryService queryService)
        {
            _commandService = commandService;
            _queryService   = queryService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserReadDto>> UserLogin([FromBody] UserLoginDto userLoginDto)
        {
            UserReadDto? user = await _queryService.LoginUser(userLoginDto.Email,userLoginDto.Password);

            if(user == null)
            {
                return BadRequest("Failed To Login");
            }

            return Ok ( user );
        }

        [HttpGet("id")]
        private async Task<ActionResult<UserReadDto>> Get(int id)
        {
            return null;
        }

        [HttpPost]
        private async Task<ActionResult<User>> Post([FromBody] UserCreateDto user)
        {
            return null;
        }


    }
}
