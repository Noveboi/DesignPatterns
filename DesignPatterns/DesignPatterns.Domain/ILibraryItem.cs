namespace DesignPatterns.Domain;

/// <summary>
/// Any type of item that exists in a library. 
/// </summary>
public interface ILibraryItem
{
    Guid Id { get; }
    string Title { get; }
}