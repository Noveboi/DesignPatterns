using DesignPatterns.Domain.Borrowing;

namespace DesignPatterns.Domain;

/// <summary>
/// A library item which represents a standard book. It can be borrowed.
/// </summary>
public sealed class Book : IBook, IBorrowable
{
    public static readonly TimeSpan DefaultLoanPeriod = TimeSpan.FromDays(14);
    
    private readonly BorrowingBehavior _borrowBehavior;
    
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Title { get; }
    public Isbn Isbn { get; }
    public BorrowStatus BorrowStatus => _borrowBehavior.Status;

    public Book(
        string title, 
        Isbn isbn, 
        BorrowingBehavior? borrowingBehavior = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        
        Title = title;
        Isbn = isbn;
        _borrowBehavior = borrowingBehavior ?? new BorrowingBehavior(new BorrowStatus(DefaultLoanPeriod));
    }

    public Result Borrow(User user) => _borrowBehavior.Borrow(user, DateTime.UtcNow);
    public Result Return(User user) => _borrowBehavior.Return(user, DateTime.UtcNow);
    public Result PayFine(User user) => _borrowBehavior.PayFine(user, DateTime.UtcNow);
}