using System.Collections.Generic;
using DotNetCoreWithMongoDB.Application.Commands;
using DotNetCoreWithMongoDB.Application.Queries;
using DotNetCoreWithMongoDB.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWithMongoDB.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookCommands _command;
        private readonly IBookQueries _queries;

        public BooksController(IBookCommands command, IBookQueries queries)
        {
            _command = command;
            _queries = queries;
        }

        /// <summary>
        /// use api/books to retrieve all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() => Ok(_queries.Get());

        /// <summary>
        /// use api/books/id to retrieve book basedon id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}")]
        public ActionResult<string> Get(string id)
        {
            var book = _queries.Get(id);

            if (book == null)
                return NotFound(book);

            return Ok(book);
        }

        /// <summary>
        /// use api/books passing in book to persit data
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            _command.Create(book);

            return CreatedAtRoute("Get", new { id = book.Id }, book);
        }

        /// <summary>
        /// use api/books/id passing in book id to update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            var foundBook = _queries.Get(book.Id);

            if (foundBook == null)
                return NotFound();

            _command.Update(book);

            return NoContent();
        }

        /// <summary>
        /// use api/books/id to delete abook record
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var foundBook = _queries.Get(id);

            if (foundBook == null)
                return NotFound();

            _command.Delete(id);

            return NoContent();
        }
    }
}
