using DesignPatterns.Domain.Borrowing;

namespace DesignPatterns.Domain.Factories;

/// <summary>
/// Factory specialized for book creation. 
/// </summary>
internal sealed class BookFactory(Isbn isbn, TimeSpan? loanPeriod) : ILibraryItemFactory
{
    public Result<ILibraryItem> Create(string itemType, string title)
    {
        var book = new Book(
            title: title,
            isbn: isbn,
            borrowingBehavior: BorrowingBehavior.Create(loanPeriod ?? Book.DefaultLoanPeriod));

        return book;
    }
}