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
            await _categoryService.CreateCategory(categoryDTO,userId);
            return Ok(categoryDTO);
        }
    }
}
