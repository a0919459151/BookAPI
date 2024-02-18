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

        public async Task<int> GetBookMaxSort()
        {
            var maxSort = await _context.Books.MaxAsync(b => (int?)b.Sort) ?? 1;

            return maxSort;
        }

        public async Task<BookEntity> CreateBook(CreateBookRequestDto request)
        {
            var bookMaxSort = await GetBookMaxSort();

            var book = new BookEntity
            {
                Title = request.Title,
                Description = request.Description,
                AuthorId = request.AuthorId,
                Sort = bookMaxSort + 1
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
            // Query source book
            var sourceBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.SourceId);
            if (sourceBook == null)
            {
                throw new Exception("Book not found");
            }

            // Query destination book
            var destinationBook = await _context.Books
                .Select(b => new { b.Id, b.Sort })
                .FirstOrDefaultAsync(b => b.Id == request.DestinationId);
            if (destinationBook == null)
            {
                throw new Exception("Book not found");
            }

            // 如果目標書籍 Sort 大於來源書籍 Sort，則將中間書籍 Sort 減 -1
            if (destinationBook.Sort > sourceBook.Sort)
            {
                var books = await _context.Books
                    .Where(b => b.Sort > sourceBook.Sort
                        && b.Sort <= destinationBook.Sort)
                    .ToListAsync();

                foreach (var book in books)
                {
                    book.Sort -= 1;
                }
            }
            // 如果目標書籍 Sort 小於來源書籍 Sort，則將中間書籍 Sort 加 1
            else
            {
                var books = await _context.Books
                    .Where(b => b.Sort < sourceBook.Sort
                        && b.Sort >= destinationBook.Sort)
                    .ToListAsync();

                foreach (var book in books)
                {
                    book.Sort += 1;
                }
            }

            // Modify source Sort to destination Sort
            sourceBook.Sort = destinationBook.Sort;
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
