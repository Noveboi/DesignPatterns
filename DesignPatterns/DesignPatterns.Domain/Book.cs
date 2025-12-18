using DesignPatterns.Domain.Borrowing;
using FluentResults;

namespace DesignPatterns.Domain;

/// <summary>
/// A library item which represents a standard book. It can be borrowed.
/// </summary>
public sealed class Book : ILibraryItem, IBorrowable
{
    public static readonly TimeSpan DefaultLoanPeriod = TimeSpan.FromDays(14);
    
    private readonly BorrowingBehavior _borrowBehavior;
    
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Title { get; }
    public BorrowStatus BorrowStatus => _borrowBehavior.Status;

    internal Book(string title, BorrowingBehavior? borrowingBehavior = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        
        Title = title;
        _borrowBehavior = borrowingBehavior ?? new BorrowingBehavior(new BorrowStatus(DefaultLoanPeriod));
    }

    public Result Borrow(User user) => _borrowBehavior.Borrow(user, DateTime.UtcNow);
    public Result Return(User user) => _borrowBehavior.Return(user, DateTime.UtcNow);
    public Result PayFine(User user) => _borrowBehavior.PayFine(user, DateTime.UtcNow);
}