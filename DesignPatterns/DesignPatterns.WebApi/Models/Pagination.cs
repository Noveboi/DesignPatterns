namespace DesignPatterns.WebApi.Models;

public sealed class Pagination
{
    public int Page { get; init; } = 1;
    public int Limit { get; init; } = 10;
}