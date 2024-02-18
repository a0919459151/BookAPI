using Book.Model.Dtos.Book;
using Book.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Get all books
        [HttpGet("List")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooks();
            return Ok(books);
        }

        // Get book by id
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var book = await _bookService.GetBook(bookId);
            return Ok(book);
        }


        // Create book
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequestDto request)
        {
            var bookId = await _bookService.CreateBook(request);
            return Ok(bookId);
        }

        // Update book
        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBook(int bookId, UpdateBookRequestDto request)
        {
            await _bookService.UpdateBook(bookId, request);
            return NoContent();
        }

        // Sort book
        [HttpPut("Sort")]
        public async Task<IActionResult> SortBook([FromBody] SortBookRequestDto request)
        {
            return Ok();
        }

        // Delete book
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await _bookService.DeleteBook(bookId);
            return NoContent();
        }
    }
}
