namespace DesignPatterns.Application.Common;

/// <summary>
/// Generic interface for querying entities. This can easily be decorated to provide additional behavior.
/// </summary>
public interface IQueries<T>
{
    Task<Result<T>> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IReadOnlyList<T>> GetAsync(GenericQueryOptions<T> options, CancellationToken ct);
}