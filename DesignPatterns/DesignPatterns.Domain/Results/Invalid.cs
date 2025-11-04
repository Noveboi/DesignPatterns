using FluentResults;

namespace DesignPatterns.Domain.Results;

public sealed class Invalid : IError
{
    public Invalid(string message, List<IError>? reasons = null)
    {
        Message = message;
        Reasons = reasons ?? [];
    }

    public string Message { get; }
    public Dictionary<string, object> Metadata { get; } = [];
    public List<IError> Reasons { get; }
}