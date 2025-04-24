using System.Linq.Expressions;

namespace TscLoanManagement.TSCDB.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

    }
}
