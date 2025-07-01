using LFTV.Domain.Entities;

namespace LFTV.Domain.Interfaces
{
    public interface IHistoryRepository : IRepository<History>
    {
        Task<IEnumerable<History>> GetByUserIdAsync(int userId);
    }
}