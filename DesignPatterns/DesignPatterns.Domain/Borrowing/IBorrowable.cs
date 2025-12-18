namespace DesignPatterns.Domain.Borrowing;

/// <summary>
/// Can be borrowed and returned by library users.
/// </summary>
public interface IBorrowable
{
    /// <summary>
    /// Returns the current state of the item in terms of borrowing/lending.
    /// </summary>
    BorrowStatus BorrowStatus { get; }
    
    /// <summary>
    /// Let the user borrow the item.
    /// </summary>
    /// <param name="user">The user who will borrow the item.</param>
    Result Borrow(User user);
    
    /// <summary>
    /// Let the user return the item.
    /// </summary>
    /// <param name="user">The user who returns the item.</param>
    Result Return(User user);

    /// <summary>
    /// Make the user pay a fine for not returning an item on time.
    /// </summary>
    /// <param name="user">The user who will pay the fine.</param>
    Result PayFine(User user);
}