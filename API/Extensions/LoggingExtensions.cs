// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Serilog;

// namespace WeightAggregationApi.Extensions;

// public static class LoggingExtensions
// {
//     public static void AddLoggingExtensions(this IServiceCollection services, IConfiguration configuration)
//     {
//         Log.Logger = new LoggerConfiguration()
//             .ReadFrom.Configuration(configuration)
//             .CreateBootstrapLogger();

//         services.AddSerilog();
//     }
// }