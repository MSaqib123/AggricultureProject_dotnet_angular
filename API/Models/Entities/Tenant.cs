namespace WeightAggregationApi.Models.Entities;

public class Tenant(Guid id = default)
{
    public Guid Id { get; init; } = id;
    public string Name { get; set; } = default!;
    public string DatabaseName { get; set; } = default!;
    public string ConnectionString { get; set; } = default!;
    public bool IsDemo { get; set; } = true;
}