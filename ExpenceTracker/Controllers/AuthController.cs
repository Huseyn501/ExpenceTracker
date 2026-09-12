using ExpenceTracker.DTOs.UserDTOs;
using ExpenceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AuthController : ControllerBase
    {

        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await authService.RegisterAsync(dto);

            if(result == null)
            {
                return BadRequest(new { Message = "Bu email artiq istifade olunur" });

            }

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result  = await authService.LoginAsync(dto);

            if(result == null)
            {
                return Unauthorized(new { Message = " Email ve ya Sifre yanlisdir" });
            }
            return Ok(result);
        }
    }
}
