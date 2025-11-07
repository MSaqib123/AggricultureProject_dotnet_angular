using System;

namespace WeightAggregationApi.Models.Entities;

public class KapasRecord
{
    public Guid Id { get; set; }
    public double WeightKg { get; set; } // Kapas weight
    public Guid PersonId { get; set; }
    public Guid? FamilyId { get; set; }
    public Guid TenantId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}