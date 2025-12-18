namespace DesignPatterns.Application.Common.Persistence;

/// <summary>
/// Represents the Unit of Work pattern. Changes to the data store are persisted only when this interface's 
/// <see cref="SaveChangesAsync"/> method is called.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Persist changes to the underlying persistence store.
    /// </summary>
    Task<Result> SaveChangesAsync(CancellationToken ct = default);
}