using System;

namespace WeightAggregationApi.Models.Entities;

public class Subscription
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = default!;
    public Guid TenantId { get; set; }
    public string Plan { get; set; } = default!; // e.g., "1month"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}