using DesignPatterns.Domain.Borrowing;
using FluentResults;

namespace DesignPatterns.Domain;

public sealed class Dvd : ILibraryItem, IBorrowable
{
    private readonly BorrowingBehavior _borrowingBehavior;
    
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Title { get; }

    public DateTime? BorrowedAtUtc => _borrowingBehavior.BorrowedAtUtc;
    public User? BorrowedBy => _borrowingBehavior.BorrowedBy;
    public TimeSpan LoanPeriod => _borrowingBehavior.LoanPeriod;

    internal Dvd(string title, BorrowingBehavior? borrowingBehavior = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        
        Title = title;
        _borrowingBehavior = borrowingBehavior ?? new BorrowingBehavior(TimeSpan.FromDays(7));
    }

    public Result Borrow(User user) => _borrowingBehavior.Borrow(user, DateTime.UtcNow);

    public Result Return(User user) => _borrowingBehavior.Return(user);
}