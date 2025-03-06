using HealthTrakerAPI.Dtos;

namespace HealthTrakerAPI.Services.Contract
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task<ServiceResponse<UserDto>> GetUserByIdAync(int userId);
        Task<ServiceResponse<UserDto>> AddUserAsync(UserDto userDto);
        Task<ServiceResponse<UserDto>> UpdateUserAsync(UserDto userDto);
        Task<ServiceResponse<bool>> DeleteUserAsync(int userId);

    }
}
