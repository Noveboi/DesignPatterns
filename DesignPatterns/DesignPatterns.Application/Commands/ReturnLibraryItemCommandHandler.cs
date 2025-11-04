using DesignPatterns.Application.Common;
using DesignPatterns.Core;
using DesignPatterns.Core.Borrowing;
using FluentResults.Extensions;

namespace DesignPatterns.Application.Commands;

internal sealed class ReturnLibraryItemCommandHandler(IQueries<ILibraryItem> items) 
    : IRequestHandler<ReturnLibraryItemCommand, Result>
{
    public Task<Result> Handle(ReturnLibraryItemCommand request, CancellationToken cancellationToken)
    {
        return Result.Ok()
            .Bind(() => items.GetByIdAsync(request.LibraryItemId, cancellationToken))
            .Bind(MapToBorrowable)
            .Bind(item => item.Return(request.Borrower));
    }
    
    private static Result<IBorrowable> MapToBorrowable(ILibraryItem item)
    {
        return item is IBorrowable borrowable
            ? Result.Ok(borrowable)
            : Result.Fail("Item cannot be returned because it cannot be borrowed.");
    }
}