using DesignPatterns.Domain;

namespace DesignPatterns.Application.Commands;

/// <summary>
/// Borrow a specific library item.
/// </summary>
public sealed class BorrowLibraryItemCommand : IRequest<Result>
{
    /// <summary>
    /// The item that will be borrowed.
    /// </summary>
    public required Guid LibraryItemId { get; init; }
    
    /// <summary>
    /// The user who will borrow the item.
    /// </summary>
    public required User Borrower { get; init; }
}