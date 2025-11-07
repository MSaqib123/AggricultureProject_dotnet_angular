using Microsoft.AspNetCore.Identity;

namespace WeightAggregationApi.Models.Entities;

public class ApplicationUser(string id = default!) : IdentityUser(id)
{
    public string? ProfilePictureUrl { get; set; }
    public Guid TenantId { get; set; }
}