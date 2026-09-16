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

        public async Task<bool> DeleteCategory(int id,string userId)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c=>c.Id == id);
            if(category == null)
            {
                return false;
            }
            _dbContext.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryResponceDTO>> GetAllCategories(string userId)
        {
            var categories = await _dbContext.Categories
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return categories.Select(x => new CategoryResponceDTO
            {
                CategoryName = x.CategoryName,
                Id = x.Id,

            }).ToList();  
        }

        public async Task<CategoryResponceDTO> GetCategoryById(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(category == null)
            {
                throw new KeyNotFoundException("Bele category yoxdu");
            }

            var categoryDTO = new CategoryResponceDTO()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            return categoryDTO;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryDTO dto, int id,string userId)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return false;
            }
            category.CategoryName = dto.CategoryName;
            return true;
        }
    }
}
