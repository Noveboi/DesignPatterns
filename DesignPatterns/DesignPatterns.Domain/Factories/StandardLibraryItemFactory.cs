using FluentResults;

namespace DesignPatterns.Core.Factories;

/// <summary>
/// Factory for constructing library items with the minimal required information.
/// </summary>
public sealed class StandardLibraryItemFactory : ILibraryItemFactory
{
    public Result<ILibraryItem> Create(string itemType, string title)
    {
        return LibraryItemMatcher.Match(itemType,
            book: () => new Book(title),
            dvd: () => new Dvd(title),
            archive: () => new Archive(title));
    }
}