using HealthTrakerAPI.Data.Contract;
using HealthTrakerAPI.Dtos;
using HealthTrakerAPI.Models;
using HealthTrakerAPI.Services.Contract;

namespace HealthTrakerAPI.Services.Implementation
{
    public class HealthDataService : IHealthDataService
    {
        private readonly IHealthDataRepository _healthDataRepository;

        public HealthDataService(IHealthDataRepository healthDataRepository)
        {
            _healthDataRepository = healthDataRepository;
        }

        public async Task<ServiceResponse<IEnumerable<HealthDataDto>>> GetAllHealthDataAsync()
        {
            var response = new ServiceResponse<IEnumerable<HealthDataDto>>();
            var healthData = await _healthDataRepository.GetAllHealthDataAsync();
            var healthDataDtos = healthData.Select(h => new HealthDataDto
            {
                HealthDataId = h.HealthDataId,
                UserId = h.UserId,
                Steps = h.Steps,
                HeartRate = h.HeartRate,
                SleepDuration = h.SleepDuration,
                Date = h.Date
            }).ToList();

            response.Data = healthDataDtos;
            response.Message = "All Health Data fetch Successfully!";
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<HealthDataDto>> GetHealthDataByIdAsync(int id)
        {
            var response = new ServiceResponse<HealthDataDto>();
            var healthData = await _healthDataRepository.GetHealthDataByIdAsync(id);

            if (healthData == null)
            {
                response.Message = "Health Data not found!";
                response.Success = false;
                return response;
            }

            response.Data = new HealthDataDto
            {
                HealthDataId = healthData.HealthDataId,
                UserId = healthData.UserId,
                Steps = healthData.Steps,
                HeartRate = healthData.HeartRate,
                SleepDuration = healthData.SleepDuration,
                Date = healthData.Date

            };
            response.Message = "Health Data fetch Successfully!";
            response.Success = true;
            return response;
        }
        public async Task<ServiceResponse<HealthDataDto>> AddHealthDataAsync(HealthDataDto healthDataDto)
        {
            var response = new ServiceResponse<HealthDataDto>();

            var healthData = new HealthData
            {
                UserId = healthDataDto.UserId,
                Steps = healthDataDto.Steps,
                HeartRate = healthDataDto.HeartRate,
                SleepDuration = healthDataDto.SleepDuration,
                Date = healthDataDto.Date
            };

            await _healthDataRepository.AddHealthDataAsync(healthData);

            response.Data = new HealthDataDto
            {
                HealthDataId = healthData.HealthDataId,
                UserId = healthData.UserId,
                Steps = healthData.Steps,
                HeartRate = healthData.HeartRate,
                SleepDuration = healthData.SleepDuration,
                Date = healthData.Date
            };
            response.Message = "Health Data added Successfully!";
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<HealthDataDto>> UpdateHealthDataAsync(HealthDataDto healthDataDto)
        {
            var response = new ServiceResponse<HealthDataDto>();
            var healthData = await _healthDataRepository.GetHealthDataByIdAsync(healthDataDto.HealthDataId);

            if (healthData == null)
            {
                response.Message = "Health data not found.";
                response.Success = false;
                return response;
            }

            healthData.UserId = healthDataDto.UserId;
            healthData.Steps = healthDataDto.Steps;
            healthData.HeartRate = healthDataDto.HeartRate;
            healthData.SleepDuration = healthDataDto.SleepDuration;
            healthData.Date = healthDataDto.Date;

            await _healthDataRepository.UpdateHealthDataAsync(healthData);

            response.Data = new HealthDataDto
            {
                HealthDataId = healthData.HealthDataId,
                UserId = healthData.UserId,
                Steps = healthData.Steps,
                HeartRate = healthData.HeartRate,
                SleepDuration = healthData.SleepDuration,
                Date = healthData.Date
            };
            response.Message = "Health Data updated Successfully!";
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteHealthDataAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            var healthData = await _healthDataRepository.GetHealthDataByIdAsync(id);

            if (healthData == null)
            {
                response.Success = false;
                response.Message = "Health data not found.";
                return response;
            }

            await _healthDataRepository.DeleteHealthDataAsync(id);
            response.Data = true;
            response.Message = "Health Data deleted Successfully!";
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<HealthDataDto>>> GetHealthDataByUserIdAsync(int userId)
        {
            var response = new ServiceResponse<IEnumerable<HealthDataDto>>();
            var healthData = await _healthDataRepository.GetHealthDataByUserIdAsync(userId);
            var healthDataDtos = healthData.Select(h => new HealthDataDto
            {
                HealthDataId = h.HealthDataId,
                UserId = h.UserId,
                Steps = h.Steps,
                HeartRate = h.HeartRate,
                SleepDuration = h.SleepDuration,
                Date = h.Date
            }).ToList();

            response.Data = healthDataDtos;
            response.Message = "Health Data By UserId fetch Successfully!";
            response.Success = true;
            return response;

        }
    }
}
