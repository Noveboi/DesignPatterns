using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.LegacyLibrary
{
    public static class BookService
    {
        public static Task Add(LibraryBook book, CancellationToken ct = default(CancellationToken))
        {
            return BookDao.Add(book, ct);
        }

        public static Task Update(LibraryBook updatedBook, CancellationToken ct = default(CancellationToken))
        {
            return BookDao.Update(updatedBook, ct);
        }
    }    
}
