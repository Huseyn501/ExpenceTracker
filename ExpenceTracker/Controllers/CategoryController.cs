using ExpenceTracker.DTOs.CategoryDTOs;
using ExpenceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            await _categoryService.CreateCategory(categoryDTO);
            return Ok(categoryDTO);
        }
    }
}
