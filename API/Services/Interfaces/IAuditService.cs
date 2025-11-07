using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WeightAggregationApi.Services.Interfaces;

public interface IAuditService
{
    Task LogAsync(HttpContext context, string entityName = default!, string oldValues = default!, string newValues = default!);
}