using ExpenceTracker.DTOs.ExpenceDTOs;
using ExpenceTracker.Services;
using ExpenceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var expence = await _expenceService.CreateExpenceAsync(dto, userId);
            return Ok(expence);
        }

        [HttpGet]
        public async Task<IActionResult> GetExpences()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var expences = await _expenceService.GetAllExpencesAsync(userId);
            return Ok(expences);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var expence = await _expenceService.GetExpenceByIdAsync(id, userId);

            if (expence == null) return NotFound();

            return Ok(expence);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteExpence(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var result = await _expenceService.DeleteExpenceAsync(id, userId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpence(int id, [FromBody] UpdateExpenceDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var result = await _expenceService.UpdateExpenceAsync(dto, userId, id);
            return Ok(result);
        }
    }
}
