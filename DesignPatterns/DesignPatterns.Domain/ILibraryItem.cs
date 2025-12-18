namespace DesignPatterns.Domain;

/// <summary>
/// Any type of item that exists in a library. 
/// </summary>
public interface ILibraryItem
{
    /// <summary>
    /// A unique identifier for the library item.
    /// </summary>
    Guid Id { get; }
    
    /// <summary>
    /// The name of the library item.
    /// </summary>
    string Title { get; }
}