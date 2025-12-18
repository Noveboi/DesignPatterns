namespace DesignPatterns.Domain.Factories;

public sealed class LibraryItemFactoryProviderOptions
{
    public TimeSpan? LoanPeriod { get; init; }
    public Isbn? Isbn { get; init; }
}