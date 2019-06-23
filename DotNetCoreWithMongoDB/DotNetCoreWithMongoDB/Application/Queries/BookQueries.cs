using System.Collections.Generic;
using DotNetCoreWithMongoDB.Domain;

namespace DotNetCoreWithMongoDB.Application.Queries
{
    public class BookQueries : IBookQueries
    {
        IBooksRepository _bookRepository;

        public BookQueries(IBooksRepository booksRepository)
        {
            _bookRepository = booksRepository;
        }

        public IEnumerable<Book> Get()
        {
            return _bookRepository.Get();
        }

        public Book Get(string id)
        {
            return _bookRepository.Get(id);
        }
    }
}
