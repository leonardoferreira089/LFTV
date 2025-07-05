using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;

namespace LFTV.Application.Services
{
    public class CalendarEntryService : ICalendarEntryService
    {
        private readonly ICalendarEntryRepository _repository;

        public CalendarEntryService(ICalendarEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CalendarEntryDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(CalendarEntryDto.FromEntity);
        }

        public async Task<CalendarEntryDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : CalendarEntryDto.FromEntity(entity);
        }

        public async Task<IEnumerable<CalendarEntryDto>> GetByMonthAsync(int year, int month)
        {
            var list = await _repository.GetByMonthAsync(year, month);
            return list.Select(CalendarEntryDto.FromEntity);
        }

        public async Task<CalendarEntryDto> CreateAsync(CreateCalendarEntryDto dto)
        {
            var entity = new CalendarEntry
            {
                Date = dto.Date,
                EmissionId = dto.EmissionId,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return CalendarEntryDto.FromEntity(entity);
        }

        public async Task UpdateAsync(int id, UpdateCalendarEntryDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("CalendarEntry not found");

            entity.Date = dto.Date;
            entity.EmissionId = dto.EmissionId;
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("CalendarEntry not found");
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
        }
    }
}