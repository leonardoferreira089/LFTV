namespace LFTV.Application.DTOs
{
    public class HistoryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProgramContentId { get; set; }
        public DateTime WatchedDate { get; set; }

        public static HistoryDto FromEntity(LFTV.Domain.Entities.History entity)
        {
            return new HistoryDto
            {
                Id = entity.Id, 
                ProgramContentId = entity.ProgramContentId,
                WatchedDate = entity.WatchedDate
            };
        }
    }
}