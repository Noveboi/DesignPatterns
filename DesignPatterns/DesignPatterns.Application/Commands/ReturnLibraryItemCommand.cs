using DesignPatterns.Domain;

namespace DesignPatterns.Application.Commands;

/// <summary>
/// Return a borrowed item to the library. 
/// </summary>
public sealed class ReturnLibraryItemCommand : IRequest<Result>
{
    /// <summary>
    /// The item that will be returned.
    /// </summary>
    public required Guid LibraryItemId { get; init; }
    
    /// <summary>
    /// The user that will return the item.
    /// </summary>
    public required User Borrower { get; init; }
}