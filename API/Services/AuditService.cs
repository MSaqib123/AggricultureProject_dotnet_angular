// using Microsoft.EntityFrameworkCore;
// using System.Text.Json;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using WeightAggregationApi.Data.Contexts;
// using WeightAggregationApi.Models.Entities;

// namespace WeightAggregationApi.Services;

// public class AuditService(TenantDbContext tenantDbContext) : IAuditService
// {
//     public async Task LogAsync(HttpContext context, string entityName = default!, string oldValues = default!, string newValues = default!)
//     {
//         var log = new AuditLog
//         {
//             UserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "anonymous",
//             TenantId = (context.Items["Tenant"] as Tenant)?.Id ?? Guid.Empty,
//             Action = context.Request.Method,
//             EntityName = entityName ?? context.Request.Path,
//             OldValues = oldValues,
//             NewValues = newValues,
//         };
//         tenantDbContext.AuditLogs.Add(log);
//         await tenantDbContext.SaveChangesAsync();
//     }
// }