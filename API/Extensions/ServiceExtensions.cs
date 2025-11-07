// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using WeightAggregationApi.Data.Contexts;
// using WeightAggregationApi.Models.Entities;
// using WeightAggregationApi.Repositories;
// using WeightAggregationApi.Repositories.Interfaces;
// using WeightAggregationApi.Services;
// using WeightAggregationApi.Services.Interfaces;

// namespace WeightAggregationApi.Extensions;

// public static class ServiceExtensions
// {
//     public static void AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
//     {
//         services.AddDbContext<ParentDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ParentConnection")));

//         services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//         {
//             options.Password.RequireDigit = true; // Advanced password policies
//             // etc.
//         })
//         .AddEntityFrameworkStores<ParentDbContext>()
//         .AddDefaultTokenProviders();

//         services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//         services.AddScoped<ITenantService, TenantService>();
//         services.AddScoped<ISubscriptionService, SubscriptionService>();
//         services.AddScoped<IEmailService, EmailService>();
//         services.AddScoped<IAuditService, AuditService>();
//         services.AddScoped<IAggregationService, AggregationService>();
//     }
// }