// using System;
// using System.Threading.Tasks;
// using WeightAggregationApi.Data.Contexts;
// using WeightAggregationApi.Models.Entities;
// using WeightAggregationApi.Services.Interfaces;

// namespace WeightAggregationApi.Services;

// public class SubscriptionService(ParentDbContext parentDbContext, ITenantService tenantService, IEmailService emailService) : ISubscriptionService
// {
//     public async Task<Subscription> CreateSubscriptionAsync(string userId, string plan)
//     {
//         var duration = plan switch
//         {
//             "1month" => TimeSpan.FromDays(30),
//             "6months" => TimeSpan.FromDays(180),
//             "1year" => TimeSpan.FromDays(365),
//             "5years" => TimeSpan.FromDays(1825),
//             _ => throw new ArgumentException("Invalid plan")
//         };

//         var sub = new Subscription
//         {
//             UserId = userId,
//             Plan = plan,
//             StartDate = DateTime.UtcNow,
//             EndDate = DateTime.UtcNow + duration,
//             IsActive = true,
//             TenantId = Guid.NewGuid()
//         };

//         _parentDbContext.Subscriptions.Add(sub);
//         await _parentDbContext.SaveChangesAsync();

//         var tenant = new Tenant(sub.TenantId) { Name = $"tenant_{userId}", DatabaseName = $"TenantDB_{sub.TenantId}", ConnectionString = $"...{sub.TenantId}" }; // Build conn string
//         await tenantService.CreateTenantDatabaseAsync(tenant, sub);
//         await emailService.SendAsync("Welcome", "...");

//         return sub;
//     }

//     public Task HandleWebhookAsync(string payload)
//     {
//         // Parse Stripe/PayPal payload, update sub, fire events
//         // e.g., if success, activate
//         return Task.CompletedTask;
//     }

//     public async Task CheckExpiryAsync(Subscription sub)
//     {
//         if (sub.EndDate < DateTime.UtcNow)
//         {
//             sub.IsActive = false;
//             await _parentDbContext.SaveChangesAsync();
//             // Revert to demo: update tenant IsDemo = true
//             await emailService.SendAsync("Subscription Expired", "...");
//         }
//     }
// }