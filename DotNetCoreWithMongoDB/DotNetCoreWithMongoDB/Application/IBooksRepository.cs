using System.Collections.Generic;
using DotNetCoreWithMongoDB.Domain;

namespace DotNetCoreWithMongoDB.Application
{
    public interface IBooksRepository
    {
        IEnumerable<Book> Get();

        Book Get(string id);

        Book Create(Book book);

        void Update(Book book);

        void Remove(Book book);

        void Remove(string id);
    }
}
