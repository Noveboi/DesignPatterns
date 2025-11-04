namespace DesignPatterns.Application.Common.Persistence;

/// <summary>
/// Generic interface for modifying entities on the backing store.
/// </summary>
public interface IRepository<in T>
{
    Result Add(T item);
    Result Remove(T item);
}