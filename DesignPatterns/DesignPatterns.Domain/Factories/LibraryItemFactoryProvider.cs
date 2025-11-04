namespace DesignPatterns.Core.Factories;

public static class LibraryItemFactoryProvider
{
    public static ILibraryItemFactory GetFactory(LibraryItemFactoryProviderOptions? options = null)
    {
        options ??= new LibraryItemFactoryProviderOptions();

        return options switch
        {
            { LoanPeriod: { } period } => new BorrowableLibraryItemFactory(period),
            _ => new StandardLibraryItemFactory()
        };
    }
}