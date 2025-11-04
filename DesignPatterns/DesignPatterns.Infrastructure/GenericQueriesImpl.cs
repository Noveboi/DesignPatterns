using DesignPatterns.Application.Common.Persistence;
using FluentResults;

namespace DesignPatterns.Infrastructure;

public sealed class GenericQueriesImpl<T> : IQueries<T>
{
    public Task<Result<T>> GetByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAsync(GenericQueryOptions<T> options, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}