using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WeightAggregationApi.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task SoftDeleteAsync(Guid id);
    Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
}