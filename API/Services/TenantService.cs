// using Microsoft.EntityFrameworkCore;
// using System.Resources;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using WeightAggregationApi.Data.Contexts;
// using WeightAggregationApi.Models.Entities;
// using System.Security.Claims;

// namespace WeightAggregationApi.Services;

// public class TenantService(ParentDbContext parentDbContext) : ITenantService
// {
//     private readonly ParentDbContext _parentDbContext = parentDbContext;

//     public async Task<Tenant?> ResolveTenantAsync(HttpContext context)
//     {
//         // Advanced resolution: subdomain > header > JWT
//         var subdomain = context.Request.Host.Host.Split('.')[0];
//         var tenant = await _parentDbContext.Tenants.FirstOrDefaultAsync(t => t.Name == subdomain);
//         if (tenant is null)
//         {
//             if (context.Request.Headers.TryGetValue("X-Tenant-Id", out var headerValue))
//             {
//                 tenant = await _parentDbContext.Tenants.FindAsync(Guid.Parse(headerValue!));
//             }
//             else if (context.User.Identity?.IsAuthenticated == true)
//             {
//                 var tenantId = context.User.FindFirst("tenant_id")?.Value;
//                 if (Guid.TryParse(tenantId, out var id))
//                     tenant = await _parentDbContext.Tenants.FindAsync(id);
//             }
//         }

//         if (tenant is null || tenant.IsDemo)
//             tenant = new Tenant { ConnectionString = _parentDbContext.Database.GetConnectionString()!.Replace("ParentDB", "SharedDemoDB"), IsDemo = true };

//         return tenant;
//     }

//     public async Task CreateTenantDatabaseAsync(Tenant tenant, Subscription subscription)
//     {
//         if (subscription.IsActive && !tenant.IsDemo)
//         {
//             // Load embedded SQL script
//             var resourceManager = new ResourceManager("WeightAggregationApi.Scripts.CreateTenantDb", typeof(TenantService).Assembly);
//             var script = resourceManager.GetString("CreateTenantDb")?.Replace("{DBName}", tenant.DatabaseName);
//             await _parentDbContext.Database.ExecuteSqlRawAsync(script!);

//             // Migrate
//             var options = new DbContextOptionsBuilder<TenantDbContext>().UseSqlServer(tenant.ConnectionString).Options;
//             using var newDb = new TenantDbContext(options);
//             await newDb.Database.MigrateAsync();
//         }
//     }
// }