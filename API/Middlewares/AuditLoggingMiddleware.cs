// // Middlewares/AuditLoggingMiddleware.cs
// using Microsoft.AspNetCore.Http;
// using System.Threading.Tasks;
// using WeightAggregationApi.Services.Interfaces;

// namespace WeightAggregationApi.Middlewares;

// public class AuditLoggingMiddleware(RequestDelegate next)
// {
//     private readonly RequestDelegate _next = next;

//     public async Task InvokeAsync(HttpContext context, IAuditService auditService)
//     {
//         // Capture request/response for auditing (advanced: body reading with EnableBuffering)
//         context.Request.EnableBuffering();
//         // Log before/after
//         await _next(context);
//         await auditService.LogAsync(context); // Implement in service
//     }
// }