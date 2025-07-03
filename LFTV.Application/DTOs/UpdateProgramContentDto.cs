namespace LFTV.Application.DTOs
{
    public class UpdateProgramContentDto
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Category { get; set; } = "";
        public string? EpisodeUrl { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsWatched { get; set; }
    }
}