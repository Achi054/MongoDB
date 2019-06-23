using System.Collections.Generic;
using DotNetCoreWithMongoDB.Application;
using DotNetCoreWithMongoDB.Domain;
using DotNetCoreWithMongoDB.Infrastructure;
using MongoDB.Driver;

namespace DotNetCoreWithMongoDB.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BooksRepository(IBooksStoreSettings booksStoreSettings)
        {
            var client = new MongoClient(booksStoreSettings.ConnectingStrings);
            var database = client.GetDatabase(booksStoreSettings.DatabaseName);

            _books = database.GetCollection<Book>(booksStoreSettings.CollectionName);
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public IEnumerable<Book> Get() =>
            _books.Find(x => true).ToList();

        public Book Get(string id) =>
            _books.Find(x => x.Id == id).FirstOrDefault();

        public void Remove(Book book) =>
            _books.DeleteOne(x => x.Id == book.Id);

        public void Remove(string id) =>
            _books.DeleteOne(x => x.Id == id);

        public void Update(Book book) =>
            _books.ReplaceOne<Book>(x => x.Id == book.Id, book);
    }
}
