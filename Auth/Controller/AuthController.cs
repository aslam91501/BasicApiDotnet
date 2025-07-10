using System.Security.Claims;
using BasicApi.Auth.Models;
using BasicApi.Auth.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Auth.Controller
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid format");
            }

            try
            {
                var response = await _authService.Login(request);
                var claims = new List<Claim>
                {
                    new Claim("UserId", response.UserId.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return Ok(new { message = "Login successful" });
            }
            catch
            {
                return Unauthorized("Invalid credentials");
            }
        }


        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { message = "Logout successful" });
        }


        [HttpGet("forbidden")]
        public IActionResult Forbidden()
        {
            return StatusCode(403, new
            {
                message = "Access denied. You don't have permission to access this resource.",
                error = "Forbidden"
            });
        }
    }
}