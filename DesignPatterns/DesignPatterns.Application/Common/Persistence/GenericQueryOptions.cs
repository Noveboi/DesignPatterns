using System.Linq.Expressions;

namespace DesignPatterns.Application.Common.Persistence;

public sealed class GenericQueryOptions<T>
{
    public int Page { get; init; } = 1;
    public int Limit { get; init; } = 10;
 
    /// <summary>
    /// The property that will be used to sort the data by default. This ensures that paginated results are consistent.
    /// </summary>
    public required Expression<Func<T, object>> DefaultSortProperty { get; init; }
    
    /// <summary>
    /// Whether to sort in ascending or descending order.
    /// </summary>
    public SortDirection SortDirection { get; init; } = SortDirection.Ascending;
}