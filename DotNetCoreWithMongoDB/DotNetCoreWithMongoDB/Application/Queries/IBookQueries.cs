using System.Collections.Generic;
using DotNetCoreWithMongoDB.Domain;

namespace DotNetCoreWithMongoDB.Application.Queries
{
    public interface IBookQueries
    {
        IEnumerable<Book> Get();

        Book Get(string id);
    }
}
