using Laskar.API.Services;
using Laskar.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laskar.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly LoginAutomataService _loginService;

        public LoginController(LoginAutomataService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Username dan password harus diisi." });
            }

            var result = _loginService.Login(request.Username, request.Password);

            if (result.StartsWith("Login gagal"))
            {
                return Unauthorized(new
                {
                    message = result,
                    state = _loginService.GetCurrentState().ToString()
                });
            }

            return Ok(new
            {
                message = result,
                role = _loginService.GetCurrentRole(),
                state = _loginService.GetCurrentState().ToString()
            });
        }


        [HttpPost("api/logout")]
        public IActionResult Logout()
        {
            _loginService.Logout(); // kosongkan loggedInUser & state
            return Ok(new { message = "Logout berhasil." });
        }

    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
