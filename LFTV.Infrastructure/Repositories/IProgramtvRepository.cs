using System;
using LFTV.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Infrastructure.Repositories
{
    public interface IProgramtvRepository
    {
        Task<IEnumerable<ProgramTv>> GetAllProgramsAsync();
        Task<ProgramTv> GetProgramByIdAsync(int id);
        Task AddProgramAsync(ProgramTv programtv);
        Task UpdateProgramAsync(ProgramTv programtv);
        Task DeleteProgramAsync(int id);
    }
}
