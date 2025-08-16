namespace LFTV.Application.DTOs
{
    public class ProgramContentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Category { get; set; } = "";
        public string? EpisodeUrl { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsWatched { get; set; }
        public int EmissionId { get; set; }
        public string? EmissionName { get; set; }
        public DateTime CreatedAt { get; set; }

        public static ProgramContentDto FromEntity(LFTV.Domain.Entities.ProgramContent entity)
        {
            return new ProgramContentDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Category = entity.Category,
                EpisodeUrl = entity.EpisodeUrl,
                ImageUrl = entity.ImageUrl,
                IsWatched = entity.IsWatched,
                EmissionId = entity.EmissionId,
                EmissionName = entity.Emission?.Name,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
