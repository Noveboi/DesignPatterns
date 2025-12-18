using DesignPatterns.Domain.Borrowing;
using DesignPatterns.Domain.Results;

namespace DesignPatterns.Domain.Factories;

internal sealed class StandardLibraryItemFactory : ILibraryItemFactory
{
    public Result<ILibraryItem> Create(string itemType, string title)
    {
        return LibraryItemMatcher.Match(itemType,
            book: () => Result.Invalid<Book>("A book requires an ISBN number"),
            dvd: () => new Dvd(title, BorrowingBehavior.Create(Dvd.DefaultLoanPeriod)),
            archive: () => new Archive(title)
        );
    }
}