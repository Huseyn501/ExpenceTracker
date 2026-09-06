using ExpenceTracker.DTOs.CategoryDTOs;

namespace ExpenceTracker.Services.Interfaces
{
    public interface ICategoryService
    {
          Task<CategoryResponceDTO> CreateCategory(CreateCategoryDTO createCategoryDTO);
    }
}
