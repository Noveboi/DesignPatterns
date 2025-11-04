using FluentResults;

namespace DesignPatterns.Domain.Borrowing;

/// <summary>
/// Can be borrowed and returned by library users.
/// </summary>
public interface IBorrowable
{
    BorrowStatus BorrowStatus { get; }
    
    Result Borrow(User user);
    Result Return(User user);
    Result PayFine(User user);
}