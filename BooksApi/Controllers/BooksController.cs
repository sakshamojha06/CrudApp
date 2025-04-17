using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { id = 1, Title = "C# in Depth", Author = "Jon Skeet"},
            new Book { id = 2, Title = "Clean Code", Author = "Robert C. Martin"}
        };

        [HttpPost]
        public IActionResult NewBook([FromBody] Book newBook)
        {
            if (newBook == null) return BadRequest();
            if (string.IsNullOrEmpty(newBook.Title)) return BadRequest("Please enter the title");
            if (string.IsNullOrEmpty(newBook.Author)) return BadRequest("Please enter the author");

            var UpdatedId = books.Count > 0 ? books.Max(bd => bd.id) : 0;
            newBook.id = UpdatedId + 1;

            books.Add(newBook);
            return Ok("Book added successfully");
        }

        [HttpGet]
        public IActionResult AllBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.id == id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.id == id);

            if (book == null) return NotFound();

            book.Author = updatedBook.Author;
            book.Title = updatedBook.Title;

            return Ok("Book is updated successfully");
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateBook(int id, [FromBody] Book partialBook)
        {
            var book = books.FirstOrDefault(b => b.id == id);
            
            if (book == null) return NotFound();
            if (string.IsNullOrEmpty(partialBook.Author) && string.IsNullOrEmpty(partialBook.Title)) return BadRequest("Please give some data, both cannot be empty at same time");

            if(!string.IsNullOrEmpty(partialBook.Author)) book.Author = partialBook.Author;
            if(!string.IsNullOrEmpty(partialBook.Title)) book.Title = partialBook.Title;
            
            return Ok("Book is updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(bd => bd.id == id);
            if (book == null) return NotFound();

            books.Remove(book);

            return Ok("Book deleted successfully");
        }
    }

    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
