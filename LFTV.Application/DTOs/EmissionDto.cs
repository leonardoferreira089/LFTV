using LFTV.Domain.Enums;

namespace LFTV.Application.DTOs
{
    public class EmissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DayOfWeekEnum Jour { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? ImageUrl { get; set; }
        public int? ProgramContentId { get; set; }
        public ProgramContentDto? ProgramContent { get; set; }
        public DateTime CreatedAt { get; set; }

        public static EmissionDto FromEntity(LFTV.Domain.Entities.Emission entity)
        {
            return new EmissionDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Jour = entity.Jour,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                ImageUrl = entity.ImageUrl,
                ProgramContentId = entity.ProgramContentId,
                ProgramContent = entity.ProgramContent != null ? ProgramContentDto.FromEntity(entity.ProgramContent) : null,
                CreatedAt = entity.CreatedAt
            };

        }
    }
}