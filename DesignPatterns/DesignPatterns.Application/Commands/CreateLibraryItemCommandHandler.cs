using DesignPatterns.Application.Common.Persistence;
using DesignPatterns.Domain;
using DesignPatterns.Domain.Factories;
using FluentResults.Extensions;

namespace DesignPatterns.Application.Commands;

internal sealed class CreateLibraryItemCommandHandler(IRepository<ILibraryItem> repository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateLibraryItemCommand, Result<ILibraryItem>>
{
    public Task<Result<ILibraryItem>> Handle(CreateLibraryItemCommand request, CancellationToken cancellationToken)
    {
        var factoryOptions = new LibraryItemFactoryProviderOptions
        {
            LoanPeriod = request.LoanPeriod,
            Isbn = request.Isbn
        };

        var factory = LibraryItemFactoryProvider.GetFactory(factoryOptions);

        return Result.Ok()
            .Bind(() => factory.Create(request.ItemType, request.Title))
            .Bind(item => repository.Add(item)
                .Bind(() => unitOfWork.SaveChangesAsync(cancellationToken))
                .ToResult(item));
    }
}