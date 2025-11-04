namespace DesignPatterns.Application.Common;

public interface IUnitOfWork
{
    Task<Result> SaveChangesAsync(CancellationToken ct);
}