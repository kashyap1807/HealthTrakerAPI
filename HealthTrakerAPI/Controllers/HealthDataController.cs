using HealthTrakerAPI.Dtos;
using HealthTrakerAPI.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthTrakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthDataController : ControllerBase
    {
        private readonly IHealthDataService _healthDataService;

        public HealthDataController(IHealthDataService healthDataService)
        {
            _healthDataService = healthDataService;
        }

        [HttpGet("GetAllHealthData")]
        public async Task<IActionResult> GetAllHealthData()
        {
            var response = await _healthDataService.GetAllHealthDataAsync();
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("GetHealthDataById/{id}")]
        public async Task<IActionResult> GetHealthDataById(int id)
        {
            var response = await _healthDataService.GetHealthDataByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost("AddHealthData")]
        public async Task<IActionResult> AddHealthData([FromBody] HealthDataDto healthDataDto)
        {
            if (healthDataDto == null)
            {
                return BadRequest("Health data is require");
            }

            var response = await _healthDataService.AddHealthDataAsync(healthDataDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtAction(nameof(GetHealthDataById), new { id = response.Data.HealthDataId }, response.Data);
        }

        [HttpPut("UpdateHealthData/{id}")]
        public async Task<IActionResult> UpdateHealthData(int id, [FromBody] HealthDataDto healthDataDto)
        {
            if (healthDataDto == null || id != healthDataDto.HealthDataId)
            {
                return BadRequest("Invalid health data.");
            }
            var response = await _healthDataService.UpdateHealthDataAsync(healthDataDto);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpDelete("DeleteHealthData/{id}")]
        public async Task<IActionResult> DeleteHealthData(int id)
        {
            var response = await _healthDataService.DeleteHealthDataAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return NoContent();

        }

        [HttpGet("GetHealthDataByUserId/{userId}")]
        public async Task<IActionResult> GetHealthDataByUserId(int userId)
        {
            var response = await _healthDataService.GetHealthDataByUserIdAsync(userId);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }
    }
}
