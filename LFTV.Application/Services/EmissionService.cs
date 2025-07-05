using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;

namespace LFTV.Application.Services
{
    public class EmissionService : IEmissionService
    {
        private readonly IEmissionRepository _repository;

        public EmissionService(IEmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmissionDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(EmissionDto.FromEntity);
        }

        public async Task<EmissionDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : EmissionDto.FromEntity(entity);
        }

        public async Task<IEnumerable<EmissionDto>> GetByDateAsync(DateTime date)
        {
            var list = await _repository.GetByDateAsync(date);
            return list.Select(EmissionDto.FromEntity);
        }

        public async Task<EmissionDto> CreateAsync(CreateEmissionDto dto)
        {
            var entity = new Emission
            {
                Name = dto.Name,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ImageUrl = dto.ImageUrl,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return EmissionDto.FromEntity(entity);
        }

        public async Task UpdateAsync(int id, UpdateEmissionDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Emission not found");

            entity.Name = dto.Name;
            entity.Date = dto.Date;
            entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime;
            entity.ImageUrl = dto.ImageUrl;
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Emission not found");
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
        }
    }
}