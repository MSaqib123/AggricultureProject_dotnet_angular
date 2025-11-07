
// // Middlewares/TenantResolutionMiddleware.cs (advanced with async, caching)
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Caching.Distributed;
// using System.Threading.Tasks;
// using WeightAggregationApi.Models.Entities;
// using WeightAggregationApi.Services.Interfaces;

// namespace WeightAggregationApi.Middlewares;

// public class TenantResolutionMiddleware(RequestDelegate next)
// {
//     private readonly RequestDelegate _next = next;

//     public async Task InvokeAsync(HttpContext context, ITenantService tenantService, IDistributedCache cache)
//     {
//         var tenant = await GetTenantAsync(context, tenantService, cache);
//         if (tenant is not null)
//         {
//             context.Items["Tenant"] = tenant;
//             var dbContext = context.RequestServices.GetRequiredService<TenantDbContext>();
//             dbContext.Database.SetConnectionString(tenant.ConnectionString);
//         }
//         await _next(context);
//     }

//     private static async Task<Tenant?> GetTenantAsync(HttpContext context, ITenantService tenantService, IDistributedCache cache)
//     {
//         var cacheKey = $"tenant_{context.Request.Host.Host}";
//         var cachedTenant = await cache.GetStringAsync(cacheKey);
//         if (!string.IsNullOrEmpty(cachedTenant))
//         {
//             // Deserialize from cache (use JSON)
//             return System.Text.Json.JsonSerializer.Deserialize<Tenant>(cachedTenant);
//         }

//         var tenant = await tenantService.ResolveTenantAsync(context);
//         if (tenant is not null)
//         {
//             await cache.SetStringAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(tenant), new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(5) });
//         }
//         return tenant;
//     }
// }