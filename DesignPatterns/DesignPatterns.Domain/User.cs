namespace DesignPatterns.Domain;

public sealed class User
{
    public Guid Id { get; } = Guid.CreateVersion7();
}