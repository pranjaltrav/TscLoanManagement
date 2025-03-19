using TscLoanManagement.TSCDB.Core.Domain.Dealer;

namespace TscLoanManagement.TSCDB.Core.Interfaces.Repositories
{
    public interface IDealerRepository : IGenericRepository<Dealer>
    {
        Task<IReadOnlyList<Dealer>> GetAllActiveDealersAsync();
        Task<Dealer> GetDealerByUserIdAsync(int userId);
    }
}
