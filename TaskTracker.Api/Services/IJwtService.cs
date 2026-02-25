using TaskTracker.Api.Models;

namespace TaskTracker.Api.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
