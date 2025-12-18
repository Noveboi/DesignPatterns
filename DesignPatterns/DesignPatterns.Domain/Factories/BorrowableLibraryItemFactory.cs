using DesignPatterns.Domain.Borrowing;
using DesignPatterns.Domain.Results;

namespace DesignPatterns.Domain.Factories;

/// <summary>
/// Factory specialized for generic borrowable item creation.
/// </summary>
internal sealed class BorrowableLibraryItemFactory(TimeSpan period) : ILibraryItemFactory
{
    public Result<ILibraryItem> Create(string itemType, string title)
    {
        return LibraryItemMatcher.Match(itemType,
            book: () => Result.Invalid<Book>("A book requires an ISBN number"),
            dvd: () => new Dvd(title, BorrowingBehavior.Create(period)),
            archive: () => Result.Invalid<Archive>("An archive cannot be borrowed and therefore does not have a loan period.") 
        );
    }
}