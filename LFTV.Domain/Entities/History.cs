using System.ComponentModel.DataAnnotations;

namespace LFTV.Domain.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Required]
        public DateTime WatchedDate { get; set; }

        // Foreign Keys
        public int ProgramContentId { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ProgramContent Program { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}