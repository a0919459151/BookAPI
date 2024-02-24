using Book.Model.Dtos.Book;
using BookEntity = Book.Model.Entities.Book;

namespace Book.Dao.Interfaces
{
    public interface IBookRepository
    {
        // GetBooks
        Task<List<BookEntity>> GetBooks();
        // GetBook
        Task<BookEntity> GetBook(int id);

        // CreateBook
        Task<BookEntity> CreateBook(CreateBookRequestDto request);

        // UpdateBook
        Task<int> UpdateBook(int id, UpdateBookRequestDto request);
        // SortBook
        Task SortBook(SortBookRequestDto request);

        // DeleteBook
        Task DeleteBook(int id);
    }
}
