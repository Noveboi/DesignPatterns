using DesignPatterns.Domain;

namespace DesignPatterns.Application.Commands;

public sealed class CreateLibraryItemCommand : IRequest<Result<ILibraryItem>>
{
    public required string ItemType { get; init; }
    public required string Title { get; init; }
    
    public TimeSpan? LoanPeriod { get; init; }
}