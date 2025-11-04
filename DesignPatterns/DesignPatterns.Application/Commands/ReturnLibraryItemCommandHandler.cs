using DesignPatterns.Application.Common;
using DesignPatterns.Core.Borrowing;
using DesignPatterns.Core.Items;
using FluentResults.Extensions;

namespace DesignPatterns.Application.Commands;

internal sealed class ReturnLibraryItemCommandHandler(ILibraryItemRepository repository) 
    : IRequestHandler<ReturnLibraryItemCommand, Result>
{
    public Task<Result> Handle(ReturnLibraryItemCommand request, CancellationToken cancellationToken)
    {
        return Result.Ok()
            .Bind(() => repository.GetAsync(request.LibraryItemId, cancellationToken))
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