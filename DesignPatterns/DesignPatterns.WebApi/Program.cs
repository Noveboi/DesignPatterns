using DesignPatterns.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblyContaining<BorrowLibraryItemCommand>());

var app = builder.Build();

app.Run();