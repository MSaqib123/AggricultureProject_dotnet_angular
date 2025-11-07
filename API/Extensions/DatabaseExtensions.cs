// // Extensions/DatabaseExtensions.cs
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using WeightAggregationApi.Data.Contexts;

// namespace WeightAggregationApi.Extensions;

// public static class DatabaseExtensions
// {
//     public static void AddDatabaseExtensions(this IServiceCollection services, IConfiguration configuration)
//     {
//         services.AddDbContextFactory<TenantDbContext>((sp, options) =>
//         {
//             // Resolved at runtime
//             options.UseSqlServer("placeholder"); // Overridden in middleware
//             options.EnableSensitiveDataLogging(configuration.GetValue<bool>("Logging:SensitiveData"));
//         });
//     }
// }