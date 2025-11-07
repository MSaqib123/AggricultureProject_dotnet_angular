// Services/Interfaces/ITenantService.cs
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WeightAggregationApi.Models.Entities;

namespace WeightAggregationApi.Services.Interfaces;

public interface ITenantService
{
    Task<Tenant?> ResolveTenantAsync(HttpContext context);
    Task CreateTenantDatabaseAsync(Tenant tenant, Subscription subscription);
}