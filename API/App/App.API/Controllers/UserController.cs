using App.API.AuthenticationService;
using App.API.Extentions.DtosExtentions;
using App.API.Services.Interfaces;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ICommandService commandService, IQueryService queryService, IAuthService authService) : ControllerBase
    {
        private readonly ICommandService _commandService = commandService;
        private readonly IQueryService _queryService = queryService;
        private readonly IAuthService _authService = authService;

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
