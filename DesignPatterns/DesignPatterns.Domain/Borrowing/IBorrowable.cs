using FluentResults;

namespace DesignPatterns.Domain.Borrowing;

/// <summary>
/// Can be borrowed and returned by library users.
/// </summary>
public interface IBorrowable
{
    DateTime? BorrowedAtUtc { get; }
    User? BorrowedBy { get; }
    TimeSpan LoanPeriod { get; }
    
    Result Borrow(User user);
    Result Return(User user);
}