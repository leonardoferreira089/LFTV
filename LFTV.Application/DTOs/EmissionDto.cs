namespace LFTV.Application.DTOs
{
    public class EmissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public static EmissionDto FromEntity(LFTV.Domain.Entities.Emission entity)
        {
            return new EmissionDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Date = entity.Date,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                ImageUrl = entity.ImageUrl,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}