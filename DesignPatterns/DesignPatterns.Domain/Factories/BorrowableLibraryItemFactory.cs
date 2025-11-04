using DesignPatterns.Core.Borrowing;
using FluentResults;

namespace DesignPatterns.Core.Factories;

/// <summary>
/// Factory for constructing library items with a loan period for borrowing purposes.
/// </summary>
/// <param name="loanPeriod">The loan period to be used.</param>
public sealed class BorrowableLibraryItemFactory(TimeSpan loanPeriod) : ILibraryItemFactory
{
    public TimeSpan LoanPeriod { get; } = loanPeriod;
    
    public Result<ILibraryItem> Create(string itemType, string title)
    {
        var borrowingBehavior = new BorrowingBehavior(LoanPeriod);
        
        return LibraryItemMatcher.Match(itemType,
            book: () => new Book(title, borrowingBehavior),
            dvd: () => new Dvd(title, borrowingBehavior),
            archive: () => new Archive(title)); // No borrowing behavior here
    }
}