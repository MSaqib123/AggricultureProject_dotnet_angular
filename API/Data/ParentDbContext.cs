// // Data/Contexts/ParentDbContext.cs
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
// using WeightAggregationApi.Models.Entities;

// namespace WeightAggregationApi.Data.Contexts;

// public class ParentDbContext(DbContextOptions<ParentDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
// {
//     public DbSet<Tenant> Tenants { get; init; } = default!;
//     public DbSet<Subscription> Subscriptions { get; init; } = default!;

//     protected override void OnModelCreating(ModelBuilder builder)
//     {
//         base.OnModelCreating(builder);
//         builder.Entity<Tenant>().HasIndex(t => t.Name).IsUnique();
//         // Advanced partitioning if needed: builder.Entity<Subscription>().ToTable("Subscriptions", b => b.IsTemporal());
//     }
// }