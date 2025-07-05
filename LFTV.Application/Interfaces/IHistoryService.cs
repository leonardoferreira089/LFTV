using LFTV.Application.DTOs;

namespace LFTV.Application.Interfaces
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryDto>> GetAllAsync();
        Task<HistoryDto?> GetByIdAsync(int id);
        Task<IEnumerable<HistoryDto>> GetByUserIdAsync(int userId);
        Task<HistoryDto> CreateAsync(CreateHistoryDto dto);
        Task UpdateAsync(int id, UpdateHistoryDto dto);
        Task DeleteAsync(int id);
    }
}