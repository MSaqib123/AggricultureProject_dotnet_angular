// using Microsoft.EntityFrameworkCore;
// using WeightAggregationApi.Models.Entities;

// namespace WeightAggregationApi.Data.Contexts;

// public class TenantDbContext(DbContextOptions<TenantDbContext> options) : DbContext(options)
// {
//     public DbSet<KapasRecord> KapasRecords { get; init; } = default!;
//     public DbSet<KaniRecord> KaniRecords { get; init; } = default!;
//     public DbSet<MaundCalculation> MaundCalculations { get; init; } = default!;
//     public DbSet<Person> Persons { get; init; } = default!;
//     public DbSet<Family> Families { get; init; } = default!;
//     public DbSet<AggregatedTotal> AggregatedTotals { get; init; } = default!;
//     public DbSet<AuditLog> AuditLogs { get; init; } = default!;

//     protected override void OnModelCreating(ModelBuilder builder)
//     {
//         base.OnModelCreating(builder);
//         // Global query filters for soft delete and TenantId
//         builder.Entity<KapasRecord>().HasQueryFilter(r => !r.IsDeleted && EF.Property<Guid>(r, "TenantId") == _currentTenantId); // _currentTenantId injected via service
//         // FKs
//         builder.Entity<KapasRecord>().HasOne<Person>().WithMany().HasForeignKey(r => r.PersonId);
//         // Indexes
//         builder.Entity<AggregatedTotal>().HasIndex(t => new { t.PersonId, t.FamilyId });
//         // Partitioning for large data: builder.Entity<AggregatedTotal>().ToTable("AggregatedTotals", b => b.IsTemporal());
//     }

//     private Guid _currentTenantId; // Set in constructor or via interceptor
//     public void SetTenantId(Guid tenantId) => _currentTenantId = tenantId;
// }