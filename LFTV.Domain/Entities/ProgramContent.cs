using System.ComponentModel.DataAnnotations;

namespace LFTV.Domain.Entities
{
    public class ProgramContent
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Type { get; set; } = string.Empty; // Série, Film, Documentaire, etc.

        [Required]
        [StringLength(100)]
        public string Category { get; set; } = string.Empty; // Action, Comédie, Drame, etc.

        [StringLength(500)]
        public string? ImageUrl { get; set; }
        public string? EpisodeUrl { get; set; }

        public bool IsWatched { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? EmissionId { get; set; }
        public Emission Emission { get; set; } = null!;
        public ICollection<History> HistoryEntries { get; set; } = new List<History>();
    }
}