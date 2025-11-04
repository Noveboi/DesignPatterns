using DesignPatterns.Domain.Borrowing;
using FluentResults;

namespace DesignPatterns.Domain;

public sealed class Book : ILibraryItem, IBorrowable
{
    private readonly BorrowingBehavior _borrowBehavior;
    
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Title { get; }
    public DateTime? BorrowedAtUtc => _borrowBehavior.BorrowedAtUtc;
    public User? BorrowedBy => _borrowBehavior.BorrowedBy;
    public TimeSpan LoanPeriod => _borrowBehavior.LoanPeriod;

    internal Book(string title, BorrowingBehavior? borrowingBehavior = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        
        Title = title;
        _borrowBehavior = borrowingBehavior ?? new BorrowingBehavior(TimeSpan.FromDays(14));
    }

    public Result Borrow(User user) => _borrowBehavior.Borrow(user, DateTime.UtcNow);
    public Result Return(User user) => _borrowBehavior.Return(user);
}