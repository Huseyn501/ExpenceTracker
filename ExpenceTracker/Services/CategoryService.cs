using ExpenceTracker.Data;
using ExpenceTracker.DTOs.CategoryDTOs;
using ExpenceTracker.Models;
using ExpenceTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenceTracker.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryResponceDTO> CreateCategory(CreateCategoryDTO createCategoryDTO, string userId)
        {
            Category category = new Category()
            {
                Id = createCategoryDTO.Id,
                CategoryName = createCategoryDTO.CategoryName,
                UserId = userId
            };
            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return new CategoryResponceDTO()
            {
                CategoryName = category.CategoryName,
                Id = category.Id
            };

        }

        public async Task<List<CategoryResponceDTO>> GetAllCategories(string userId)
        {
            var expences = await _dbContext.Categories
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return expences.Select(x => new CategoryResponceDTO
            {
                CategoryName = x.CategoryName,
                Id = x.Id,

            }).ToList();  
        }
    }
}
