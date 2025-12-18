using DesignPatterns.Domain;
using DesignPatterns.Domain.Borrowing;
using DesignPatterns.LegacyLibrary;
using FluentResults;

namespace DesignPatterns.Infrastructure.Adapters;

/// <summary>
/// Adapter for the "legacy" system's book model. Also uses the Decorator design pattern.
/// </summary>
public sealed class LegacyBookAdapter : IBook, IBorrowable
{
    private readonly Book _book;

    private LegacyBookAdapter(Book book)
    {
        _book = book;
    }

    public static LegacyBookAdapter FromLegacy(LibraryBook legacyBook)
    {
        var book = new Book(
            title: legacyBook.Name,
            isbn: new Isbn(legacyBook.Isbn));
        
        return new LegacyBookAdapter(book);
    }

    public LibraryBook ToLegacy()
    {
        return new LibraryBook
        {
            Isbn = Isbn.ToString(),
            Name = Title,
            Status = BorrowStatus switch
            {
                { IsBorrowed: true } => LibraryItemStatus.Borrowed,
                _ => LibraryItemStatus.Available
            }
        };
    }

    public Guid Id => _book.Id;
    public string Title => _book.Title;
    public Isbn Isbn => _book.Isbn;
    public BorrowStatus BorrowStatus => _book.BorrowStatus;

    public Result Borrow(User user) => _book.Borrow(user);
    public Result Return(User user) => _book.Return(user);
    public Result PayFine(User user) => _book.PayFine(user);
}