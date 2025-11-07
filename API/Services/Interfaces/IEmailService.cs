// Services/Interfaces/IEmailService.cs
using System.Threading.Tasks;

namespace WeightAggregationApi.Services.Interfaces;

public interface IEmailService
{
    Task SendAsync(string subject, string body, string to = default!);
}