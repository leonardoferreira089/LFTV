namespace LFTV.Application.DTOs
{
    public class CreateHistoryDto
    {
        public int UserId { get; set; }
        public int ProgramContentId { get; set; }
        public DateTime WatchedAt { get; set; }
    }
}