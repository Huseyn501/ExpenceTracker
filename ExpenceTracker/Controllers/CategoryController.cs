using ExpenceTracker.DTOs.CategoryDTOs;
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
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO categoryDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var createdCategory = await _categoryService.CreateCategory(categoryDTO, userId);
            return CreatedAtAction(nameof(GetAllCategories), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var categories = await _categoryService.GetAllCategories(userId);
            return Ok(categories);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategoryById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var category = await _categoryService.GetCategoryById(id, userId);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _categoryService.DeleteCategory(id, userId);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO categoryDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _categoryService.UpdateCategory(categoryDTO, id, userId);
            return NoContent();
        }
    }
}
