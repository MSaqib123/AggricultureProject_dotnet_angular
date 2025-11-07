// // Services/EmailService.cs (SendGrid stub)
// using SendGrid;
// using SendGrid.Helpers.Mail;
// using System.Threading.Tasks;

// namespace WeightAggregationApi.Services;

// public class EmailService(IConfiguration configuration) : IEmailService
// {
//     private readonly string _apiKey = configuration["SendGrid:ApiKey"]!;

//     public async Task SendAsync(string subject, string body, string to = default!)
//     {
//         var client = new SendGridClient(_apiKey);
//         var msg = MailHelper.CreateSingleEmail(new EmailAddress("no-reply@saas.com"), new EmailAddress(to), subject, body, body);
//         await client.SendEmailAsync(msg);
//     }
// }