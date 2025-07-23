using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;

namespace LFTV.Application.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _repository;

        public HistoryService(IHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HistoryDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(HistoryDto.FromEntity);
        }

        public async Task<HistoryDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : HistoryDto.FromEntity(entity);
        }

        public async Task<IEnumerable<HistoryDto>> GetByUserIdAsync(int userId)
        {
            var list = await _repository.GetByUserIdAsync(userId);
            return list.Select(HistoryDto.FromEntity);
        }

        public async Task<HistoryDto> CreateAsync(CreateHistoryDto dto)
        {
            var entity = new History
            {
                ProgramContentId = dto.ProgramContentId,
                WatchedDate = dto.WatchedAt
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return HistoryDto.FromEntity(entity);
        }

        public async Task UpdateAsync(int id, UpdateHistoryDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("History not found");
            entity.WatchedDate = dto.WatchedAt;
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("History not found");
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
        }
    }
}