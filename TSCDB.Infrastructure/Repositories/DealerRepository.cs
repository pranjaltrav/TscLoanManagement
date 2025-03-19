using Microsoft.EntityFrameworkCore;
using TscLoanManagement.TSCDB.Core.Domain.Dealer;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;
using TscLoanManagement.TSCDB.Infrastructure.Data.Context;

namespace TscLoanManagement.TSCDB.Infrastructure.Repositories
{
    public class DealerRepository : GenericRepository<Dealer>, IDealerRepository
    {
        public DealerRepository(TSCDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Dealer>> GetAllActiveDealersAsync()
        {
            return await _context.Dealers.Where(d => d.IsActive).ToListAsync();
        }

        public async Task<Dealer> GetDealerByUserIdAsync(int userId)
        {
            return await _context.Dealers.FirstOrDefaultAsync(d => d.UserId == userId);
        }
    }
}
