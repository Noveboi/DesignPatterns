using DesignPatterns.Domain.Borrowing;

namespace DesignPatterns.Domain;

/// <summary>
/// A library item that represents a typical DVD that can be borrowed.
/// </summary>
public sealed class Dvd : ILibraryItem, IBorrowable
{
    public static readonly TimeSpan DefaultLoanPeriod = TimeSpan.FromDays(7);
    
    private readonly BorrowingBehavior _borrowBehavior;
    
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Title { get; }
    public BorrowStatus BorrowStatus => _borrowBehavior.Status;

    internal Dvd(string title, BorrowingBehavior? borrowingBehavior = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        
        Title = title;
        _borrowBehavior = borrowingBehavior ?? new BorrowingBehavior(new BorrowStatus(DefaultLoanPeriod));
    }

    public Result Borrow(User user) => _borrowBehavior.Borrow(user, DateTime.UtcNow);
    public Result Return(User user) => _borrowBehavior.Return(user, DateTime.UtcNow);
    public Result PayFine(User user) => _borrowBehavior.PayFine(user, DateTime.UtcNow);
}