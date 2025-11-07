// using Microsoft.EntityFrameworkCore;
// using System.Linq;
// using System.Threading.Tasks;
// using WeightAggregationApi.Data.Contexts;
// using WeightAggregationApi.Models.Entities;

// namespace WeightAggregationApi.Services;

// public class AggregationService(TenantDbContext tenantDbContext) : IAggregationService
// {
//     public async Task<AggregatedTotal> CalculateTotalsAsync(Guid personId, Guid? familyId = null)
//     {
//         var kapas = await tenantDbContext.KapasRecords.Where(r => r.PersonId == personId && !r.IsDeleted).SumAsync(r => r.WeightKg);
//         var kani = await tenantDbContext.KaniRecords.Where(r => r.PersonId == personId && !r.IsDeleted).SumAsync(r => r.WeightKani); // Assume conversion logic
//         var maund = kapas / 40; // 1 Maund = 40 kg

//         var total = new AggregatedTotal
//         {
//             PersonId = personId,
//             FamilyId = familyId,
//             TotalKapas = kapas,
//             TotalKani = kani,
//             TotalMaund = maund
//         };

//         tenantDbContext.AggregatedTotals.Update(total); // Upsert
//         await tenantDbContext.SaveChangesAsync();
//         return total;
//     }
// }