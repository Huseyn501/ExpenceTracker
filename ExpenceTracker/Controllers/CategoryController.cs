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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var createdCategory = await _categoryService.CreateCategory(categoryDTO, userId);
            return CreatedAtAction(nameof(GetAllCategories), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) {
                return Unauthorized(); }

            var categories = await _categoryService.GetAllCategories(userId);
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            ;
            var result = await _categoryService.DeleteCategory(id,userId);
            if (result == false)
            {
                return NotFound(new { Message = "Category not found" });
            }
            return NoContent();
        }

        [HttpPut("{id}")]
                                                                                                          
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryDTO categoryDTO,int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            ;
            var result = await _categoryService.UpdateCategory(categoryDTO, id, userId);
            if(result == false)
            {
                return NotFound(new { Message = "Category not found" });
            }
            return NoContent();

        }
    }
}
