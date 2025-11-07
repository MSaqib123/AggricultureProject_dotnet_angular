using System.Threading.Tasks;
using WeightAggregationApi.Models.Entities;

namespace WeightAggregationApi.Services.Interfaces;

public interface ISubscriptionService
{
    Task<Subscription> CreateSubscriptionAsync(string userId, string plan);
    Task HandleWebhookAsync(string payload); // For Stripe/PayPal
    Task CheckExpiryAsync(Subscription sub);
}