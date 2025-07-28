using LFTV.Domain.Entities;
using LFTV.Domain.Enums;

namespace LFTV.Domain.Interfaces
{
    public interface IEmissionRepository : IRepository<Emission>
    {
        Task<IEnumerable<Emission>> GetByJourAsync(DayOfWeekEnum jour);
    }
}