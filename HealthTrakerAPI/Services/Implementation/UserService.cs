using HealthTrakerAPI.Data.Contract;
using HealthTrakerAPI.Dtos;
using HealthTrakerAPI.Models;
using HealthTrakerAPI.Services.Contract;

namespace HealthTrakerAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var response = new ServiceResponse<IEnumerable<UserDto>>();
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                
                if (users == null || !users.Any())
                {
                    response.Success = false;
                    response.Message = "No users found.";
                    return response;
                }

                var userDtos = users.Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Age = u.Age,
                    Weight = u.Weight,
                    Height = u.Height
                }).ToList();

                response.Data = userDtos;
                response.Message = "All Users fetch Successfully!";
                response.Success = true;
                //return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<UserDto>> GetUserByIdAync(int userId)
        {
            var response = new ServiceResponse<UserDto>();
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                if (user == null)
                {
                    response.Message = "User not found!";
                    response.Success = false;
                    return response;
                }

                response.Data = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Age = user.Age,
                    Weight = user.Weight,
                    Height = user.Height
                };

                response.Message = "User fetch Successfully!";
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }
            
            return response;
        }

        public async Task<ServiceResponse<UserDto>> AddUserAsync(UserDto userDto)
        {
            var response = new ServiceResponse<UserDto>();
            try
            {

                if (userDto == null)
                {
                    response.Success = false;
                    response.Message = "User data is required.";
                    return response;
                }
                var user = new User
                {
                    Name = userDto.Name,
                    Age = userDto.Age,
                    Weight = userDto.Weight,
                    Height = userDto.Height
                };

                await _userRepository.AddUserAsync(user);

                response.Data = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Age = user.Age,
                    Weight = user.Weight,
                    Height = user.Height
                };
                response.Message = "New User Added Successfully!";
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<UserDto>> UpdateUserAsync(UserDto userDto)
        {
            var response = new ServiceResponse<UserDto>();
            try
            {

                var user = await _userRepository.GetUserByIdAsync(userDto.UserId);

                if (user == null)
                {
                    response.Message = "User not found!";
                    response.Success = false;
                    return response;
                }

                user.Name = userDto.Name;
                user.Age = userDto.Age;
                user.Weight = userDto.Weight;
                user.Height = userDto.Height;

                await _userRepository.UpdateUserAsync(user);

                response.Data = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Age = user.Age,
                    Weight = user.Weight,
                    Height = user.Height
                };

                response.Message = "User Updated Successfully!";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteUserAsync(int userId)
        {
            var response = new ServiceResponse<bool>();
            try
            {

                var user = await _userRepository.GetUserByIdAsync(userId);

                if (user == null)
                {
                    response.Message = "User not found!";
                    response.Success = false;
                    return response;
                }

                await _userRepository.DeleteUserAsync(userId);
                response.Data = true;
                response.Message = "User Deleted Successfully!";
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }
    }
}
