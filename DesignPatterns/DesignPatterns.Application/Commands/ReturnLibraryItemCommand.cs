using DesignPatterns.Core;

namespace DesignPatterns.Application.Commands;

public sealed class ReturnLibraryItemCommand : IRequest<Result>
{
    public required Guid LibraryItemId { get; init; }
    public required User Borrower { get; init; }
}