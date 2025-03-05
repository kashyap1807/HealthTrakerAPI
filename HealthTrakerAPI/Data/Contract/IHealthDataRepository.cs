using HealthTrakerAPI.Models;

namespace HealthTrakerAPI.Data.Contract
{
    public interface IHealthDataRepository
    {
        Task<IEnumerable<HealthData>> GetAllHealthDataAsync();
        Task<HealthData> GetHealthDataByIdAsync(int id);
        Task AddHealthDataAsync(HealthData healthData);
        Task UpdateHealthDataAsync(HealthData healthData);
        Task DeleteHealthDataAsync(int id);
        Task<IEnumerable<HealthData>> GetHealthDataByUserIdAsync(int userId);
    }
}
