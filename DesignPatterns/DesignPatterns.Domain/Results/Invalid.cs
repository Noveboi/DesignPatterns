using FluentResults;

namespace DesignPatterns.Domain.Results;

public sealed class Invalid(string message, List<IError>? reasons = null) : IError
{
    public string Message { get; } = message;
    public Dictionary<string, object> Metadata { get; } = [];
    public List<IError> Reasons { get; } = reasons ?? [];
}