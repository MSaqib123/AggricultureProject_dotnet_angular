// // Extensions/VersioningExtensions.cs
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.DependencyInjection;

// namespace WeightAggregationApi.Extensions;

// public static class VersioningExtensions
// {
//     public static void AddVersioningExtensions(this IServiceCollection services)
//     {
//         services.AddApiVersioning(options =>
//         {
//             options.DefaultApiVersion = new ApiVersion(1, 0);
//             options.AssumeDefaultVersionWhenUnspecified = true;
//             options.ReportApiVersions = true;
//         }).AddVersionedApiExplorer(options =>
//         {
//             options.GroupNameFormat = "'v'VVV";
//             options.SubstituteApiVersionInUrl = true;
//         });
//     }
// }