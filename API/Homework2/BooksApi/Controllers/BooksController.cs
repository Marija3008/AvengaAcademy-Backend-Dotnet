using BooksApi.Data;
using BooksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(BookDatabase.Books);
        }

        [HttpGet("by-index")]
        public ActionResult<Book> GetBookByIndex([FromQuery] int index)
        {
            if (index < 0 || index >= BookDatabase.Books.Count)
            {
                return NotFound("Book not found at the specified index.");
            }
            return Ok(BookDatabase.Books[index]);
        }


        //cleaner less code
        //[HttpGet]
        //public ActionResult GetBooks([FromQuery] int? index)
        //{
        //    if (index == null)
        //    {
        //        return Ok(BookDatabase.Books);

        //    }

        //    if (index < 0 || index >= BookDatabase.Books.Count)
        //    {
        //        return NotFound("Book not found at the specified index.");
        //    }

        //    return Ok(BookDatabase.Books[index.Value]);

        //}

        [HttpGet("search")]
        public ActionResult<List<Book>> SearchBooks(
            [FromQuery] string? author,
            [FromQuery] string? title)
        {
            var books = BookDatabase.Books.AsEnumerable();

            if (!string.IsNullOrEmpty(author))
            {
                books = books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(title))
            {
                books = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(books.ToList());
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            BookDatabase.Books.Add(book);
            return Ok(book);
        }

        [HttpPost("titles")]
        public ActionResult<List<string>> GetBookTitles([FromBody] List<Book> books)
        {
            var titles = books.Select(b => b.Title).ToList();
            return Ok(titles);
        }
    }
}
