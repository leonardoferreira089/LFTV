using LFTV.Domain.Entities;
using LFTV.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Infrastructure.Services
{
    public class ProgramTvService : IProgramTvService
    {
        private readonly IProgramtvRepository _repository;

        public ProgramTvService(IProgramtvRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProgramTv>> GetAllProgramsAsync()
        {
            return await _repository.GetAllProgramsAsync();
        }

        public async Task<ProgramTv> GetProgramByIdAsync(int id)
        {
            return await _repository.GetProgramByIdAsync(id);
        }

        public async Task AddProgramAsync(ProgramTv programTv)
        {
            await _repository.AddProgramAsync(programTv);
        }

        public async Task UpdateProgramAsync(ProgramTv programTv)
        {
            await _repository.UpdateProgramAsync(programTv);
        }

        public async Task DeleteProgramAsync(int id)
        {
            await _repository.DeleteProgramAsync(id);
        }
    }
}
