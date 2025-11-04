using DesignPatterns.Core;

namespace DesignPatterns.Application.Common;

public interface ILibraryItemRepository
{
    Task<Result<ILibraryItem>> GetAsync(Guid id, CancellationToken ct);
    
    Result Add(ILibraryItem item);
    Result Remove(ILibraryItem item);
}