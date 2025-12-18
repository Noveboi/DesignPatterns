namespace DesignPatterns.Application.Common.Persistence;

/// <summary>
/// Generic interface for querying entities. This can easily be decorated to provide additional behavior.
/// </summary>
public interface IQueries<T>
{
    /// <summary>
    /// Retrieve an entity by using its unique identifier.
    /// </summary>
    Task<Result<T>> GetByIdAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Retrieve a collection of entities 
    /// </summary>
    Task<IReadOnlyList<T>> GetAsync(GenericQueryOptions<T> options, CancellationToken ct = default);
}