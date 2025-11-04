namespace DesignPatterns.Core;

public sealed class Archive(string title) : ILibraryItem
{
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Title { get; } = title;
}