using Book.Dao.Interfaces;
using Book.Model.Dtos.Book;
using Microsoft.EntityFrameworkCore;
using BookEntity = Book.Model.Entities.Book;

namespace Book.Dao.Repositories
{
    public class BookReposotory : IBookReposotory
    {
        private readonly BookApiDBContext _context;

        public BookReposotory(BookApiDBContext context)
        {
            _context = context;
        }

        public async Task<List<BookEntity>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<BookEntity> GetBook(int id)
        {
            var book = await _context.Books.SingleAsync(b => b.Id == id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            return book;
        }

        public async Task<BookEntity> CreateBook(CreateBookRequestDto request)
        {
            var book = new BookEntity
            {
                Title = request.Title,
                Description = request.Description,
                AuthorId = request.AuthorId
            };

            await _context.Books.AddAsync(book);

            return book;
        }

        public async Task<int> UpdateBook(int id, UpdateBookRequestDto request)
        {
            var book = await _context.Books.SingleAsync(b => b.Id == id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            book.Title = request.Title;
            book.Description = request.Description;
            book.AuthorId = request.AuthorId;

            return book.Id;
        }

        public async Task SortBook(SortBookRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.SingleAsync(b => b.Id == id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            _context.Remove(book);
        }
      
    }
}
