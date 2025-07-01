using LFTV.Domain.Entities;

namespace LFTV.Domain.Interfaces
{
    public interface IEmissionRepository : IRepository<Emission>
    {
        Task<IEnumerable<Emission>> GetByDateAsync(DateTime date);
    }
}