using HealthTrakerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthTrakerAPI.Data
{
    public class HealthTrackerContext : DbContext
    {
        public HealthTrackerContext(DbContextOptions<HealthTrackerContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<HealthData> HealthData { get; set; }
    }
}
