using DesignPatterns.Application.Common.Persistence;
using FluentResults;

namespace DesignPatterns.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    public Task<Result> SaveChangesAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}