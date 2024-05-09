using Gym.API.Models;
using Gym.Application.DTOs.User;
using Gym.Application.Interfaces;
using Gym.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticate _authenticate;

        public UserController(IUserService userService, IAuthenticate authenticate)
        {
            _userService = userService;
            _authenticate = authenticate;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] CreateUserDTO createUserDTO)
        {
            var user = await _userService.CreateAsync(createUserDTO);
            var token = await _authenticate.GenerateToken(user.Data.Email, user.Data.Id);
            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserLogin userLogin)
        {
            if (!await _authenticate.UserExist(userLogin.Email))
            {
                return BadRequest("E-mail não existe!");
            };

            var result = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Password);
            if (!result)
            {
                return BadRequest("Usuário ou senha inválidos.");
            }

            var user = await _authenticate.GetUserByEmail(userLogin.Email);

            var token = await _authenticate.GenerateToken(user.Email, user.Id);
            return new UserToken
            {
                Token = token
            };
        }

    }
}
