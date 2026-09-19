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
                
                CategoryName = createCategoryDTO.CategoryName,
                UserId = userId
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return new CategoryResponceDTO()
            {
                CategoryName = category.CategoryName,
                Id = category.Id
            };
        }

        public async Task<bool> DeleteCategory(int id, string userId)
        {
            
            var category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (category == null)
            {

                throw new KeyNotFoundException("Category not found or you do not have permission to access it.");
            }

            _dbContext.Categories.Remove(category);
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
                Id = x.Id
            }).ToList();
        }

        public async Task<CategoryResponceDTO> GetCategoryById(int id, string userId)
        {
            
            var category = await _dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (category == null)
            {
                throw new KeyNotFoundException("Category not found or you do not have permission to access it.");
            }

            return new CategoryResponceDTO()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public async Task<bool> UpdateCategory(UpdateCategoryDTO dto, int id, string userId)
        {
          
            var category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (category == null)
            {
                throw new KeyNotFoundException("Category not found or you do not have permission to access it.");
            }

            category.CategoryName = dto.CategoryName;

            
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}