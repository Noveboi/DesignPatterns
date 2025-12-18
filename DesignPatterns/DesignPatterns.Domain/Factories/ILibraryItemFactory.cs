namespace DesignPatterns.Domain.Factories;

/// <summary>
/// An abstract factory
/// </summary>
public interface ILibraryItemFactory
{
    Result<ILibraryItem> Create(string itemType, string title);
}