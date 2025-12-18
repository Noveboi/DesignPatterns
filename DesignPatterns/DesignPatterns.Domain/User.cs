namespace DesignPatterns.Domain;

/// <summary>
/// The standard user of the system. 
/// </summary>
public sealed class User
{
    public Guid Id { get; } = Guid.CreateVersion7();
}