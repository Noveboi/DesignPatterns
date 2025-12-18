namespace DesignPatterns.Application.Common.Persistence;

/// <summary>
/// Generic interface for modifying entities on the backing store.
/// </summary>
public interface IRepository<in T>
{
    /// <summary>
    /// Mark an entity as "Added", then use <see cref="IUnitOfWork"/> to save changes and persist
    /// </summary>
    Result Add(T entity);
    
    /// <summary>
    /// Mark an entity as "Deleted", then use <see cref="IUnitOfWork"/> to save changes and persist
    /// </summary>
    Result Remove(T entity);
}