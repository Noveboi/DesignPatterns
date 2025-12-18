using DesignPatterns.Application.Common.Persistence;
using FluentResults;

namespace DesignPatterns.Infrastructure;

public sealed class GenericRepositoryImpl<T> : IRepository<T>
{
    public Result Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Result Remove(T entity)
    {
        throw new NotImplementedException();
    }
}