using LFTV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Infrastructure.Services
{
    public interface IProgramTvService
    {
        Task<IEnumerable<ProgramTv>> GetAllProgramsAsync();
        Task<ProgramTv> GetProgramByIdAsync(int id);
        Task AddProgramAsync(ProgramTv programTv);
        Task UpdateProgramAsync(ProgramTv programTv);
        Task DeleteProgramAsync(int id);
    }
}
