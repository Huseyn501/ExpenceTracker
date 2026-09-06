using ExpenceTracker.DTOs.UserDTOs;

namespace ExpenceTracker.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> RegisterAsync(RegisterDto Dto);
        Task<AuthResponseDto?> LoginAsync(LoginDto Dto);
    }
}
