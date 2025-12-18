using DesignPatterns.Domain;

namespace DesignPatterns.Application.Commands;

/// <summary>
/// Add a new item to the library. 
/// </summary>
public sealed class CreateLibraryItemCommand : IRequest<Result<ILibraryItem>>
{
    /// <summary>
    /// The type of library item.
    /// </summary>
    public required string ItemType { get; init; }
    
    /// <summary>
    /// The name/title of the library item.
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// OPTIONAL: The amount of time that the item can be borrowed.
    /// </summary>
    public TimeSpan? LoanPeriod { get; init; }
    
    /// <summary>
    /// OPTIONAL: The ISBN of a book, if the item is of a book type.
    /// </summary>
    public Isbn? Isbn { get; init; }
}