namespace DesignPatterns.Domain.Results;

public sealed class NotFound(Type type) : IError
{
    public string Message { get; } = $"{type.Name} does not exist.";
    public Dictionary<string, object> Metadata { get; } = [];
    public List<IError> Reasons { get; } = [];
}