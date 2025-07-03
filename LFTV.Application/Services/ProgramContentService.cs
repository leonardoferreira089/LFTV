using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;

namespace LFTV.Application.Services
{
    public class ProgramContentService : IProgramContentService
    {
        private readonly IProgramContentRepository _repository;

        public ProgramContentService(IProgramContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProgramContentDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(pc => ProgramContentDto.FromEntity(pc));
        }

        public async Task<ProgramContentDto?> GetByIdAsync(int id)
        {
            var pc = await _repository.GetByIdAsync(id);
            return pc == null ? null : ProgramContentDto.FromEntity(pc);
        }

        public async Task<IEnumerable<ProgramContentDto>> GetByEmissionIdAsync(int emissionId)
        {
            var list = await _repository.GetByEmissionIdAsync(emissionId);
            return list.Select(pc => ProgramContentDto.FromEntity(pc));
        }

        public async Task<ProgramContentDto> CreateAsync(CreateProgramContentDto dto)
        {
            var entity = new ProgramContent
            {
                Name = dto.Name,
                Type = dto.Type,
                Category = dto.Category,
                EmissionId = dto.EmissionId,
                EpisodeUrl = dto.EpisodeUrl,
                ImageUrl = dto.ImageUrl,
                IsWatched = false,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return ProgramContentDto.FromEntity(entity);
        }

        public async Task UpdateAsync(int id, UpdateProgramContentDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("ProgramContent not found");

            entity.Name = dto.Name;
            entity.Type = dto.Type;
            entity.Category = dto.Category;
            entity.EpisodeUrl = dto.EpisodeUrl;
            entity.ImageUrl = dto.ImageUrl;
            entity.IsWatched = dto.IsWatched;
            // entity.EmissionId = dto.EmissionId; // optionnel
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("ProgramContent not found");
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
        }
    }
}