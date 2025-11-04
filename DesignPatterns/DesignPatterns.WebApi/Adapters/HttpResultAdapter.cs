using DesignPatterns.Domain.Results;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.WebApi.Adapters;

/// <summary>
/// Adapter that maps a <see cref="FluentResults.Result"/> to an ASP.NET Core <see cref="IResult"/> instance.
/// </summary>
public static class HttpResultAdapter
{
    public static IResult Adapt<T>(this Result<T> result)
    {
        return result switch
        {
            { IsSuccess: true, ValueOrDefault: { } val } => TypedResults.Ok(val),
            { IsSuccess: true, ValueOrDefault: null } => TypedResults.Ok(),
            { Errors: [NotFound error] } => TypedResults.NotFound(error.Message),
            { Errors: [Invalid invalid] } => TypedResults.BadRequest(new ProblemDetails
            {
                Title = invalid.Message,
                Status = 400
            }),
            { Errors: [{ } error] } => TypedResults.UnprocessableEntity(error.Message),
            _ => TypedResults.InternalServerError()
        };
    }

    public static async Task<IResult> AdaptAsync<T>(this Task<Result<T>> resultTask)
    {
        return (await resultTask).Adapt();
    }
}