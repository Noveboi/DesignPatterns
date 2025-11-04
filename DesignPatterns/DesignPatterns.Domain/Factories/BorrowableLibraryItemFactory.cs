using DesignPatterns.Domain.Borrowing;
using FluentResults;

namespace DesignPatterns.Domain.Factories;

/// <summary>
/// Factory for constructing library items with a loan period for borrowing purposes.
/// </summary>
/// <param name="loanPeriod">The loan period to be used.</param>
public sealed class BorrowableLibraryItemFactory(TimeSpan loanPeriod) : ILibraryItemFactory
{
    public TimeSpan LoanPeriod { get; } = loanPeriod;
    
    public Result<ILibraryItem> Create(string itemType, string title)
    {
        return LibraryItemMatcher.Match(itemType,
            book: () => new Book(title, new BorrowingBehavior(new BorrowStatus(LoanPeriod, 2))),
            dvd: () => new Dvd(title, new BorrowingBehavior(new BorrowStatus(LoanPeriod, 1.25))),
            archive: () => new Archive(title)); // No borrowing behavior here
    }
}