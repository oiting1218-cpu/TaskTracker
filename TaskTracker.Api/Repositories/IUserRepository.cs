using TaskTracker.Api.Models;

namespace TaskTracker.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
