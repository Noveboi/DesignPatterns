using DesignPatterns.Core.Items;
using FluentResults;

namespace DesignPatterns.Core.Factories;

/// <summary>
/// Defines strongly typed and exhaustive 'switch' branches for library item types.
/// </summary>
internal static class LibraryItemMatcher
{
    public static Result<ILibraryItem> Match(
        string itemType,
        Func<Book> book,
        Func<Dvd> dvd,
        Func<Archive> archive)
    {
        return itemType.ToLowerInvariant() switch
        {
            "book" => book(),
            "dvd" => dvd(),
            "archive" => archive(),
            _ => Result.Fail($"Item type '{itemType}' does not exist.")
        };
    }
}