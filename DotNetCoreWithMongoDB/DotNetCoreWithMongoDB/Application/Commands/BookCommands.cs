using DotNetCoreWithMongoDB.Domain;

namespace DotNetCoreWithMongoDB.Application.Commands
{
    public class BookCommands : IBookCommands
    {
        IBooksRepository _bookRepository;

        public BookCommands(IBooksRepository booksRepository)
        {
            _bookRepository = booksRepository;
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public void Delete(Book book)
        {
            _bookRepository.Remove(book);
        }

        public void Delete(string id)
        {
            _bookRepository.Remove(id);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
