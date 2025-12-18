namespace DesignPatterns.Domain;

public interface IBook : ILibraryItem
{
    Isbn Isbn { get; }
}