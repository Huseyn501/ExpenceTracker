using ExpenceTracker.DTOs.CategoryDTOs;

namespace ExpenceTracker.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponceDTO> CreateCategory(CreateCategoryDTO createCategoryDTO, string userId);
        Task<List<CategoryResponceDTO>> GetAllCategories(string userId);
        Task<CategoryResponceDTO> GetCategoryById(int id);

        Task<bool> DeleteCategory(int id, string userId);
        Task<bool> UpdateCategory(UpdateCategoryDTO dto, int id, string userId);


    }
}
