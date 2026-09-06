using ExpenceTracker.DTOs;
using ExpenceTracker.DTOs.ExpenceDTOs;

namespace ExpenceTracker.Services.Interfaces
{
    public interface IExpenceService
    {
        Task<List<ExpenceResponseDTO>> GetAllExpencesAsync(string userId);

        Task<ExpenceResponseDTO> GetExpenceByIdAsync(int ExpenceId, string userId);

        Task<ExpenceResponseDTO> CreateExpenceAsync(CreateExpenceDTO createExpenceDTO, string userId);

        Task<bool> DeleteExpenceAsync(int expenceId, string userId);


        Task<bool> UpdateExpenceAsync(UpdateExpenceDTO updateExpenceDTO, string userId,int expenceId);



    }
}
