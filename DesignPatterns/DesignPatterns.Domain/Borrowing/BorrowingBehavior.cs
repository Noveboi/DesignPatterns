using FluentResults;

namespace DesignPatterns.Core.Borrowing;

/// <summary>
/// Configurable behavior for Borrowing an item.
/// </summary>
public sealed class BorrowingBehavior
{
    public BorrowingBehavior(
        TimeSpan loanPeriod, 
        User? borrowedBy = null, 
        DateTime? borrowedAtUtc = null)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(loanPeriod, TimeSpan.FromDays(1));

        LoanPeriod = loanPeriod;
        BorrowedBy = borrowedBy;
        BorrowedAtUtc = borrowedAtUtc;
    }

    public TimeSpan LoanPeriod { get; }
    public User? BorrowedBy { get; private set; } 
    public DateTime? BorrowedAtUtc { get; private set; }
    public DateTime? DueDate => BorrowedAtUtc + LoanPeriod;
    
    public Result Borrow(User user, DateTime time)
    {
        if (BorrowedAtUtc is not null)
        {
            return Result.Fail($"Item has already been borrowed at {BorrowedAtUtc:F}");
        }

        BorrowedAtUtc = time;
        BorrowedBy = user;

        return Result.Ok();
    }

    public Result Return(User user)
    {
        if (BorrowedAtUtc is null || BorrowedBy is null)
        {
            return Result.Fail("Item has not been borrowed");
        }

        if (BorrowedBy != user)
        {
            return Result.Fail($"{user} has not borrowed this item.");
        }

        BorrowedBy = null;
        BorrowedAtUtc = null;
        
        return Result.Ok();
    }
}