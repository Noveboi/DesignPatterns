using DesignPatterns.Application.Common.Persistence;
using DesignPatterns.Domain;
using DesignPatterns.Domain.Borrowing;
using FluentResults.Extensions;

namespace DesignPatterns.Application.Commands;

internal sealed class BorrowLibraryItemCommandHandler(IQueries<ILibraryItem> items) 
    : IRequestHandler<BorrowLibraryItemCommand, Result>
{
    public Task<Result> Handle(BorrowLibraryItemCommand request, CancellationToken cancellationToken)
    {
        return Result.Ok()
            .Bind(() => items.GetByIdAsync(request.LibraryItemId, cancellationToken))
            .Bind(MapToBorrowable)
            .Bind(item => item.Borrow(request.Borrower));
    }

    private static Result<IBorrowable> MapToBorrowable(ILibraryItem item)
    {
        return item is IBorrowable borrowable
            ? Result.Ok(borrowable)
            : Result.Fail("Item cannot be borrowed.");
    }
}