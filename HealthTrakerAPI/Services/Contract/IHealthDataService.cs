using HealthTrakerAPI.Dtos;

namespace HealthTrakerAPI.Services.Contract
{
    public interface IHealthDataService
    {
        Task<ServiceResponse<IEnumerable<HealthDataDto>>> GetAllHealthDataAsync();
        Task<ServiceResponse<HealthDataDto>> GetHealthDataByIdAsync(int id);
        Task<ServiceResponse<HealthDataDto>> AddHealthDataAsync(HealthDataDto healthDataDto);
        Task<ServiceResponse<HealthDataDto>> UpdateHealthDataAsync(HealthDataDto healthDataDto);
        Task<ServiceResponse<bool>> DeleteHealthDataAsync(int id);
        Task<ServiceResponse<IEnumerable<HealthDataDto>>> GetHealthDataByUserIdAsync(int userId);
    }
}
