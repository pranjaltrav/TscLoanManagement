using TscLoanManagement.TSCDB.Core.Domain.Loan;

namespace TscLoanManagement.TSCDB.Core.Interfaces.Repositories
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<IReadOnlyList<Loan>> GetLoansByDealerIdAsync(int dealerId);
        Task<Loan> GetLoanWithDetailsAsync(int loanId);
    }
}
