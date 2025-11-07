using System;

namespace WeightAggregationApi.Models.Entities;

public class AuditLog
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = default!;
    public Guid TenantId { get; set; }
    public string Action { get; set; } = default!; // Create/Update/Delete
    public string EntityName { get; set; } = default!;
    public string OldValues { get; set; } = default!; // JSON
    public string NewValues { get; set; } = default!; // JSON
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}