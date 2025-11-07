// // Controllers/v1/RecordsController.cs
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using WeightAggregationApi.Models.Entities;
// using WeightAggregationApi.Models.Responses;
// using WeightAggregationApi.Repositories.Interfaces;
// using WeightAggregationApi.Services.Interfaces;

// namespace WeightAggregationApi.Controllers.v1;

// [ApiVersion("1.0")]
// [Route("api/v{version:apiVersion}/[controller]")]
// [ApiController]
// [Authorize(Policy = "TenantPolicy")]
// public class RecordsController(IGenericRepository<KapasRecord> repository, IAggregationService aggregationService, IAuditService auditService) : ControllerBase
// {
//     [HttpGet]
//     public async Task<ApiResponse<IQueryable<KapasRecord>>> GetAll(int page = 1, int size = 10, string? filter = null)
//     {
//         var query = repository.GetAll(); // Auto-filtered by tenant
//         // Apply filter if provided (parse to Expression)
//         var paged = query.Skip((page - 1) * size).Take(size);
//         return new ApiResponse<IQueryable<KapasRecord>>(true, paged);
//     }

//     [HttpPost]
//     public async Task<ApiResponse<Guid>> Add([FromBody] KapasRecord record)
//     {
//         await repository.AddAsync(record);
//         await auditService.LogAsync(HttpContext, nameof(KapasRecord), string.Empty, System.Text.Json.JsonSerializer.Serialize(record));
//         await aggregationService.CalculateTotalsAsync(record.PersonId, record.FamilyId); // Auto-aggregate
//         return new ApiResponse<Guid>(true, record.Id);
//     }

//     // Similar for Update, Delete (soft), GetById
//     // Add endpoints for Kani, Maund, Export (CSV via library like CsvHelper)
// }