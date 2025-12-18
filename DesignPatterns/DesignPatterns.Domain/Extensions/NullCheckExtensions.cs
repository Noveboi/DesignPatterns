using System.Diagnostics.CodeAnalysis;

namespace DesignPatterns.Domain.Extensions;

public static class NullCheckExtensions
{
    [return: NotNull]
    public static T ThrowIfNull<T>(this T? instance)
    {
        return instance ?? throw new InvalidOperationException("Expected instance to not be null");
    }
}