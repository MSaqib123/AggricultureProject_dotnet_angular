// // Repositories/GenericRepository.cs (advanced with expressions, pagination)
// using Microsoft.EntityFrameworkCore;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using WeightAggregationApi.Data.Contexts;

// namespace WeightAggregationApi.Repositories;

// public class GenericRepository<T>(TenantDbContext context) : IGenericRepository<T> where T : class
// {
//     private readonly DbSet<T> _set = context.Set<T>();

//     public async Task<T?> GetByIdAsync(Guid id) => await _set.FindAsync(id);

//     public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null)
//     {
//         var query = _set.AsQueryable();
//         if (filter is not null) query = query.Where(filter);
//         return query;
//     }

//     public async Task AddAsync(T entity)
//     {
//         // Demo limit check
//         var tenant = HttpContextAccessor.HttpContext?.Items["Tenant"] as Tenant; // Inject IHttpContextAccessor
//         if (tenant?.IsDemo == true && await CountAsync() >= 50)
//             throw new InvalidOperationException("Demo limit reached (50 records)");

//         await _set.AddAsync(entity);
//         await context.SaveChangesAsync();
//     }

//     public async Task UpdateAsync(T entity)
//     {
//         _set.Update(entity);
//         await context.SaveChangesAsync();
//     }

//     public async Task SoftDeleteAsync(Guid id)
//     {
//         var entity = await GetByIdAsync(id);
//         if (entity is not null)
//         {
//             if (entity is { } withDeleted) // Pattern matching
//             {
//                 var prop = typeof(T).GetProperty("IsDeleted");
//                 prop?.SetValue(entity, true);
//                 prop = typeof(T).GetProperty("DeletedAt");
//                 prop?.SetValue(entity, DateTime.UtcNow);
//                 await UpdateAsync(entity);
//             }
//         }
//     }

//     public Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
//     {
//         var query = _set.AsQueryable();
//         if (filter is not null) query = query.Where(filter);
//         return query.CountAsync();
//     }
// }