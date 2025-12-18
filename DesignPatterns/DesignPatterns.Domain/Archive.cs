namespace DesignPatterns.Domain;

/// <summary>
/// A library item which cannot be borrowed and is mainly for library staff.
/// </summary>
/// <param name="title"></param>
public sealed class Archive(string title) : ILibraryItem
{
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Title { get; } = title;
}