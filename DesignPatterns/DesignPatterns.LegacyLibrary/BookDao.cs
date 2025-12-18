using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.LegacyLibrary
{
    internal static class BookDao
    {
        public static Task Add(LibraryBook book, CancellationToken cancellation = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
        
        public static Task Update(LibraryBook book, CancellationToken cancellation = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}

