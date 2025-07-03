namespace LFTV.Application.DTOs
{
    public class CreateProgramContentDto
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Category { get; set; } = "";
        public int EmissionId { get; set; }
        public string? EpisodeUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}