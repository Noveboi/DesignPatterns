namespace DesignPatterns.Domain.Factories;

public static class LibraryItemFactoryProvider
{
    public static ILibraryItemFactory GetFactory(LibraryItemFactoryProviderOptions? options = null)
    {
        options ??= new LibraryItemFactoryProviderOptions();

        return options switch
        {
            { Isbn: { } isbn } => new BookFactory(isbn, options.LoanPeriod), 
            { LoanPeriod: { } period } => new BorrowableLibraryItemFactory(period),
            _ => new StandardLibraryItemFactory()
        };
    }
}