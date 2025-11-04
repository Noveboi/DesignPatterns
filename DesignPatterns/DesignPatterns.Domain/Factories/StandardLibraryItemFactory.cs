using DesignPatterns.Core.Items;

namespace DesignPatterns.Core.Factories;

/// <summary>
/// Factory for constructing library items with the minimal required information.
/// </summary>
public sealed class StandardLibraryItemFactory : ILibraryItemFactory
{
    public ILibraryItem Create(string itemType, string title)
    {
        return LibraryItemMatcher.Match(itemType,
            book: () => new Book(title),
            dvd: () => new Dvd(title),
            archive: () => new Archive(title));
    }
}