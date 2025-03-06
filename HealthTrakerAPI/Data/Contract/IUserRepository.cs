using HealthTrakerAPI.Models;

namespace HealthTrakerAPI.Data.Contract
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
