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
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

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
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

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
            // Query destination book
            var destinationBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.DestinationId);
            if (destinationBook == null)
            {
                throw new Exception("Book not found");
            }

            // Query source book
            var sourceBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.SourceId);
            if (sourceBook == null)
            {
                throw new Exception("Book not found");
            }

            // Swap book sort
            (sourceBook.Id, destinationBook.Id) = (destinationBook.Id, sourceBook.Id);

            // 如果目標書籍 id 大於來源書籍 id，則將來源書籍 id 到目標書籍 id 之間的書籍 id 減 -1
            if (destinationBook.Id > sourceBook.Id)
            {
                var books = await _context.Books.Where(b => b.Id > sourceBook.Id && b.Id <= destinationBook.Id).ToListAsync();
                foreach (var book in books)
                {
                    book.Id--;
                }
            }
            // 如果目標書籍 id 小於來源書籍 id，則將來源書籍 id 到目標書籍 id 之間的書籍 id 加 1
            else
            {
                var books = await _context.Books.Where(b => b.Id < sourceBook.Id && b.Id >= destinationBook.Id).ToListAsync();
                foreach (var book in books)
                {
                    book.Id++;
                }
            }

        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            _context.Remove(book);
        }
      
    }
}
