using FluentResults;

namespace DesignPatterns.Core.Factories;

/// <summary>
/// An abstract factory
/// </summary>
public interface ILibraryItemFactory
{
    /// <summary>
    /// Create a library item by specifying its type.
    /// </summary>
    /// <param name="itemType">The type of library item to create</param>
    /// <param name="title">The title of the item.</param>
    Result<ILibraryItem> Create(string itemType, string title);
}