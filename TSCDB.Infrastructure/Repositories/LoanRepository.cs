using Microsoft.EntityFrameworkCore;
using TscLoanManagement.TSCDB.Core.Domain.Loan;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;
using TscLoanManagement.TSCDB.Infrastructure.Data.Context;

namespace TscLoanManagement.TSCDB.Infrastructure.Repositories
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(TSCDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Loan>> GetLoansByDealerIdAsync(int dealerId)
        {
            return await _context.Loans
                .Where(l => l.DealerId == dealerId)
                .ToListAsync();
        }

        public async Task<Loan> GetLoanWithDetailsAsync(int loanId)
        {
            return await _context.Loans
                .Include(l => l.VehicleInfo)
                .Include(l => l.BuyerInfo)
                .Include(l => l.Attachments)
                .FirstOrDefaultAsync(l => l.Id == loanId);
        }
    }
}
