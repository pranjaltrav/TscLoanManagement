using TscLoanManagement.TSCDB.Core.Domain.Authentication;

namespace TscLoanManagement.TSCDB.Core.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<int> SaveChangesAsync();
    }
}
