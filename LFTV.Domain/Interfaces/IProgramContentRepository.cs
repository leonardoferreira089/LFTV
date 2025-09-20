using LFTV.Domain.Entities;

namespace LFTV.Domain.Interfaces
{
    public interface IProgramContentRepository : IRepository<ProgramContent>
    {
        Task<IEnumerable<ProgramContent>> GetByEmissionSelectionIdAsync(int? emissionSelectionId);        
    }
}