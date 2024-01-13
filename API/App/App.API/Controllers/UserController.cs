using App.API.AuthenticationService;
using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.Interfaces;
using App.API.Servises.Interfaces;
using App.Models.Dtos.Post;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandService _commandService;
        private readonly IQueryService _queryService;
        private readonly IAuthService _authService;

        public UserController(ICommandService commandService,IQueryService queryService,IAuthService authService)
        {
            _commandService = commandService;
            _queryService   = queryService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserReadDto>> UserLogin([FromBody] UserLoginDto userLoginDto)
        {
            UserReadDto? userRead = await _queryService.LoginUser(userLoginDto.Email,userLoginDto.Password);

            if(userRead == null)
            {
                return BadRequest("Failed To Login");
            }

            await HttpContext.SignInAsync(Auth.Scheme.UserCookie, _authService.CreateUserClaimsPrincipal(userRead.ToEntity(), Auth.Scheme.UserCookie));

            return Ok (userRead);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            UserReadDto? user = await _queryService.ReadUserAsync(id);

            if(user == null)
            {
                return NotFound($"User with id = [{id}] not found");
            }

            return Ok( user );
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserReadDto>> UserRegister([FromBody] UserCreateDto user)
        {
            UserReadDto? userReadDto = await _commandService.UserRegisterAsync(user);

            if(userReadDto == null)
            {
                return BadRequest($"Failed to register user with email: [{user.Email}]");
            }

            return Ok( userReadDto );
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> UserDelete(int Id)
        {
            bool deleted = await _commandService.UserDeleteAsync(Id);

            if (deleted)
                return Ok();

            return NotFound();
        }
    }
}
