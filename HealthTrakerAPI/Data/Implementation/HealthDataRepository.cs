using HealthTrakerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthTrakerAPI.Data.Implementation
{
    public class HealthDataRepository
    {
        private readonly HealthTrackerContext _context;

        public HealthDataRepository(HealthTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HealthData>> GetAllHealthDataAsync()
        {
            return await _context.HealthData.ToListAsync();
        }

        public async Task<HealthData> GetHealthDataByIdAsync(int id)
        {
            return await _context.HealthData.FindAsync(id);
        }

        public async Task AddHealthDataAsync(HealthData healthData)
        {
            _context.HealthData.Add(healthData);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHealthDataAsync(HealthData healthData)
        {
            _context.HealthData.Update(healthData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHealthDataAsync(int id)
        {
            var healtData = await _context.HealthData.FindAsync(id);
            if(healtData != null)
            {
                _context.HealthData.Remove(healtData);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<HealthData>> GetHealthDataByUserIdAsync(int userId)
        {
            return await _context.HealthData.Where(h => h.UserId == userId).ToListAsync();
        }
    }
}
