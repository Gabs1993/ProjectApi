using BasicApi.Data.DTOs.UserDTO;
using BasicApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            var token = _tokenService.Login(loginDTO.Email, loginDTO.Password);

            if (token == null)
            {
                return Unauthorized("Email ou senha inválidos");
            }

            return Ok(new { token });
        }


    }
}
