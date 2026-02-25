using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Services
{
    public interface IAuthService
    {
        Task RegisterUser(RegisterUserDto dto);

        Task<AuthResponseDto?> Login(LoginDto dto);
    }
}
