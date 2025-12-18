using DesignPatterns.Application.Commands;
using DesignPatterns.Application.Common.Persistence;
using DesignPatterns.Domain;
using DesignPatterns.Infrastructure;
using DesignPatterns.WebApi;
using DesignPatterns.WebApi.Adapters;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepositoryImpl<>));
builder.Services.AddScoped(typeof(IQueries<>), typeof(GenericQueriesImpl<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblyContaining<BorrowLibraryItemCommand>());

var app = builder.Build();

app.MapGet("/items", (int page, int limit, IQueries<ILibraryItem> items, CancellationToken ct) =>
{
    var options = new GenericQueryOptions<ILibraryItem>
    {
        DefaultSortProperty = x => x.Title,
        PageNumber = page,
        PageSize = limit,
    };

    return items.GetAsync(options, ct);
});

app.MapGet("/items/{id:guid}", (Guid id, IQueries<ILibraryItem> items, CancellationToken ct) => 
    items.GetByIdAsync(id, ct).AdaptAsync());


app.MapPost("items", (CreateLibraryItemRequest req, ISender sender, CancellationToken ct) =>
{
    var command = new CreateLibraryItemCommand
    {
        Title = req.Title,
        ItemType = req.ItemType,
        LoanPeriod = req.LoanPeriodDays is { } days ? TimeSpan.FromDays(days) : null,
        Isbn = req.Isbn is { } isbn ? new Isbn(isbn) : null,
    };

    return sender.Send(command, ct).AdaptAsync();
});

app.Run();

namespace DesignPatterns.WebApi
{
    internal sealed record CreateLibraryItemRequest(
        string ItemType, 
        string Title, 
        int? LoanPeriodDays,
        string? Isbn);
}