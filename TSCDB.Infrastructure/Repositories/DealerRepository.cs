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
            return await _context.Dealers
                .Include(d => d.User)
                .Where(d => d.IsActive)
                .ToListAsync();
        }


        public async Task<Dealer> GetDealerByUserIdAsync(int id)
        {
            return await _context.Dealers
                .Include(d => d.ChequeDetails)
                .Include(d => d.BorrowerDetails)
                .Include(d => d.GuarantorDetails)
                .Include(d => d.SecurityDepositDetails)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
