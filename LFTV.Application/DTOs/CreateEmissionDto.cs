using LFTV.Domain.Enums;

namespace LFTV.Application.DTOs
{
    public class CreateEmissionDto
    {
        public string Name { get; set; } = "";
        public DayOfWeekEnum Jour { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? ImageUrl { get; set; }
        public int ProgramContentId { get; set; }
        public ProgramContentDto? ProgramContent { get; set; }
    }
}