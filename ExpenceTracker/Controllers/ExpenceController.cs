using ExpenceTracker.DTOs.ExpenceDTOs;
using ExpenceTracker.Services;
using ExpenceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceController : ControllerBase
    {
       private readonly IExpenceService _expenceService;

        public ExpenceController(IExpenceService expenceService)
        {
            _expenceService = expenceService;
        }

       [HttpPost]
       public async Task<IActionResult> CreateExpence([FromBody] CreateExpenceDTO dto)
        {
            var userId = "test123214";
            var expence = await _expenceService.CreateExpenceAsync(dto, userId);
            return Ok(expence);
        }

    
    }
}
