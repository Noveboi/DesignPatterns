namespace DesignPatterns.Core;

public sealed class User
{
    public Guid Id { get; } = Guid.CreateVersion7();
}