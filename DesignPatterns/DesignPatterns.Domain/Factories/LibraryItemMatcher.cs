namespace DesignPatterns.Domain.Factories;

/// <summary>
/// Defines strongly typed and exhaustive 'switch' branches for library item types.
/// </summary>
internal static class LibraryItemMatcher
{
    public static Result<ILibraryItem> Match(
        string itemType,
        Func<Result<Book>> book,
        Func<Result<Dvd>> dvd,
        Func<Result<Archive>> archive)
    {
        return itemType.ToLowerInvariant() switch
        {
            "book" => book().Map(ILibraryItem (x) => x),
            "dvd" => dvd().Map(ILibraryItem (x) => x),
            "archive" => archive().Map(ILibraryItem (x) => x),
            _ => Result.Fail($"Item type '{itemType}' does not exist.")
        };
    }
}