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
    private readonly LibraryBook _adaptee;
    
    private LegacyBookAdapter(Book book, LibraryBook adaptee)
    {
        _book = book;
        _adaptee = adaptee;
    }

    public static LegacyBookAdapter FromLegacy(LibraryBook legacyBook)
    {
        var book = new Book(
            title: legacyBook.Name,
            isbn: new Isbn(legacyBook.Isbn));
        
        return new LegacyBookAdapter(book, legacyBook);
    }

    public Guid Id => _book.Id;
    public string Title => _book.Title;
    public Isbn Isbn => _book.Isbn;
    public BorrowStatus BorrowStatus => _book.BorrowStatus;

    public Result Borrow(User user) => _book.Borrow(user);
    public Result Return(User user) => _book.Return(user);
    public Result PayFine(User user) => _book.PayFine(user);
}