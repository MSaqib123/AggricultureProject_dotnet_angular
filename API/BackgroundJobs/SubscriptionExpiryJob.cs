// using System.Threading.Tasks;
// using WeightAggregationApi.Data.Contexts;
// using Microsoft.EntityFrameworkCore;

// namespace WeightAggregationApi.BackgroundJobs;

// public class SubscriptionExpiryJob(ISubscriptionService subscriptionService, ParentDbContext parentDbContext)
// {
//     public async Task Execute(CancellationToken token = default)
//     {
//         var subs = await parentDbContext.Subscriptions.Where(s => s.IsActive).ToListAsync(token);
//         foreach (var sub in subs)
//         {
//             await subscriptionService.CheckExpiryAsync(sub);
//         }
//     }
// }