using DesignPatterns.Domain.Results;
using FluentResults;

namespace DesignPatterns.Domain.Borrowing;

/// <summary>
/// Configurable behavior for Borrowing an item.
/// </summary>
public sealed record BorrowingBehavior(BorrowStatus Status)
{
    public BorrowStatus Status { get; private set; } = Status;
    
    public Result Borrow(User user, DateTime time)
    {
        if (Status.IsBorrowed)
        {
            return Result.Invalid($"Item has already been borrowed at {Status.BorrowedAtUtc:F}");
        }

        Status = Status with
        {
            BorrowedAtUtc = time,
            BorrowedBy = user
        };

        return Result.Ok();
    }

    public Result Return(User user, DateTime time)
    {
        if (!Status.IsBorrowed)
        {
            return Result.Invalid("Item has not been borrowed");
        }

        if (Status.BorrowedBy != user)
        {
            return Result.Invalid($"{user} has not borrowed this item.");
        }

        if (time >= Status.DueDate && !Status.HasPaidFine)
        {
            return Result.Invalid("The item has been returned late and you must pay a fine before returning it.");
        }

        Status = Status with
        {
            BorrowedBy = null,
            BorrowedAtUtc = null
        };
        
        return Result.Ok();
    }

    public Result PayFine(User user, DateTime time)
    {
        if (!Status.IsBorrowed)
        {
            return Result.Invalid("Item has not been borrowed");
        }

        if (Status.BorrowedBy != user)
        {
            return Result.Invalid($"{user} has not borrowed this item.");
        }

        if (time < Status.DueDate)
        {
            return Result.Invalid("The item's loan period has not ended yet.");
        }

        if (Status.HasPaidFine)
        {
            return Result.Invalid("The fine has already been paid");
        }

        Status = Status with
        {
            HasPaidFine = true
        };
        
        return Result.Ok();
    }
}