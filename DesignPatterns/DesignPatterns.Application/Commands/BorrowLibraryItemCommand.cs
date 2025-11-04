using DesignPatterns.Core;

namespace DesignPatterns.Application.Commands;

public sealed class BorrowLibraryItemCommand : IRequest<Result>
{
    public required Guid LibraryItemId { get; init; }
    public required User Borrower { get; init; }
}