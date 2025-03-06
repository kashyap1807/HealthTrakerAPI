namespace HealthTrakerAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public ICollection<HealthData> HealthData { get; set; }
    }
}
