namespace LFTV.Application.DTOs
{
    public class CreateEmissionDto
    {
        public string Name { get; set; } = "";
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? ImageUrl { get; set; }
    }
}