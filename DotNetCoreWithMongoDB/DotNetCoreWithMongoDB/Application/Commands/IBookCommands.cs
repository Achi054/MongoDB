using DotNetCoreWithMongoDB.Domain;

namespace DotNetCoreWithMongoDB.Application.Commands
{
    public interface IBookCommands
    {
        Book Create(Book book);
        void Update(Book book);
        void Delete(Book book);
        void Delete(string id);
    }
}
