namespace WeightAggregationApi.Models.Responses;

public class ApiResponse<T>(bool success = true, T? data = default, string? message = null, List<string>? errors = null)
{
    public bool Success { get; } = success;
    public T? Data { get; } = data;
    public string? Message { get; } = message;
    public List<string> Errors { get; } = errors ?? [];
}