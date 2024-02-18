using Book.Dao.Interfaces;
using Book.Model.Dtos.Book;
using Book.Service.Interfaces;

namespace Book.Service.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookReposotory _bookReposotory;

        public BookService(IUnitOfWork unitOfWork, IBookReposotory bookReposotory)
        {
            _unitOfWork = unitOfWork;
            _bookReposotory = bookReposotory;
        }

        public async Task<List<GetBooksResponseDto>> GetBooks()
        {
            var books = await _bookReposotory.GetBooks();

            var bookdto = books.Select(b => new GetBooksResponseDto
            {
                Id = b.Id,
                Title = b.Title,
                Sort = b.Sort
            })
            .OrderBy(b => b.Sort)
            .ToList();

            return bookdto;
        }

        public async Task<GetBookResponseDto> GetBook(int id)
        {
            var book = await _bookReposotory.GetBook(id);

            return new GetBookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Sort = book.Sort,
                AuthorId = book.AuthorId
            };
        }

        public async Task<int> CreateBook(CreateBookRequestDto request)
        {
            var book = await _bookReposotory.CreateBook(request);

            await _unitOfWork.SaveChanges();

            return book.Id;
        }

        public async Task UpdateBook(int id, UpdateBookRequestDto request)
        {
            await _bookReposotory.UpdateBook(id, request);

            await _unitOfWork.SaveChanges();
        }

        public async Task SortBook(SortBookRequestDto request)
        {
            await _bookReposotory.SortBook(request);

            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteBook(int id)
        {
            await _bookReposotory.DeleteBook(id);

            await _unitOfWork.SaveChanges();
        }

    }
}
