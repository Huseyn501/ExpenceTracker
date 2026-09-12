using ExpenceTracker.Data;
using ExpenceTracker.DTOs.CategoryDTOs;
using ExpenceTracker.Models;
using ExpenceTracker.Services.Interfaces;

namespace ExpenceTracker.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryResponceDTO> CreateCategory(CreateCategoryDTO createCategoryDTO,string userId)
        {
            Category category = new Category()
            {
                Id = createCategoryDTO.Id,
                CategoryName = createCategoryDTO.CategoryName,
                UserId = userId
            };
            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return  new CategoryResponceDTO()
            {
                CategoryName = category.CategoryName,
                Id = category.Id
            };

        }
    }
}
