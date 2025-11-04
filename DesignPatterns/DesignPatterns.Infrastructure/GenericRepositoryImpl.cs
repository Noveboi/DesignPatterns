using DesignPatterns.Application.Common.Persistence;
using FluentResults;

namespace DesignPatterns.Infrastructure;

public sealed class GenericRepositoryImpl<T> : IRepository<T>
{
    public Result Add(T item)
    {
        throw new NotImplementedException();
    }

    public Result Remove(T item)
    {
        throw new NotImplementedException();
    }
}