using LFTV.Domain.Entities;
using LFTV.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            await _repository.AddAsync(schedule);
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            await _repository.UpdateAsync(schedule);
        }

        public async Task DeleteScheduleAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
