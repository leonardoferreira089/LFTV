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
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<ProgramContent> Contents { get; set; } = new List<ProgramContent>();
        public ICollection<CalendarEntry> CalendarEntries { get; set; } = new List<CalendarEntry>();
    }
}