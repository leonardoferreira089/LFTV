using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using LFTV.Domain.Entities;
using LFTV.Domain.Enums;
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

        public async Task<IEnumerable<EmissionDto>> GetByJourAsync(DayOfWeek jour)
        {
            var jourEnum = (LFTV.Domain.Enums.DayOfWeekEnum)((int)jour); // +1 car System.DayOfWeek commence à 0 pour dimanche
            var list = await _repository.GetByJourAsync(jourEnum);
            return list.Select(EmissionDto.FromEntity);
        }

        public async Task<EmissionDto> CreateAsync(CreateEmissionDto dto)
        {
            var entity = new Emission
            {
                Name = dto.Name,
                Jour = dto.Jour,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ImageUrl = dto.ImageUrl,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return EmissionDto.FromEntity(entity);
        }

        private List<DayOfWeekEnum> ExpandDays(DayOfWeekEnum jour)
        {
            switch (jour)
            {
                case DayOfWeekEnum.LundiAVendredi:
                    return new List<DayOfWeekEnum>
            {
                DayOfWeekEnum.Lundi, DayOfWeekEnum.Mardi, DayOfWeekEnum.Mercredi,
                DayOfWeekEnum.Jeudi, DayOfWeekEnum.Vendredi
            };
                case DayOfWeekEnum.SamediDimanche:
                    return new List<DayOfWeekEnum>
            {
                DayOfWeekEnum.Samedi, DayOfWeekEnum.Dimanche
            };
                default:
                    return new List<DayOfWeekEnum> { jour };
            }
        }

        public async Task UpdateAsync(int id, UpdateEmissionDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Emission not found");

            entity.Name = dto.Name;
            entity.Jour = dto.Jour;
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