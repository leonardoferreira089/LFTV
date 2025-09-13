using LFTV.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LFTV.Domain.Entities
{
    public class Emission
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DayOfWeekEnum Jour { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties       
        public ProgramContent? ProgramContent { get; set; }
        public ICollection<CalendarEntry> CalendarEntries { get; set; } = new List<CalendarEntry>();
    }
}