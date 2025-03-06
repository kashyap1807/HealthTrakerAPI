namespace HealthTrakerAPI.Dtos
{
    public class HealthDataDto
    {
        public int HealthDataId { get; set; }
        public int UserId { get; set; }
        public int Steps { get; set; }
        public int HeartRate { get; set; }
        public double SleepDuration { get; set; }
        public DateTime Date { get; set; }
    }
}
