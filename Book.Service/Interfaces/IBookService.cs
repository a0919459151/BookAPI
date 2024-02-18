using Book.Model.Dtos.Book;

namespace Book.Service.Interfaces
{
    public interface IBookService
    {
        // GetBooks
        Task<List<GetBooksResponseDto>> GetBooks();
        // GetBook
        Task<GetBookResponseDto> GetBook(int id);

        // CreateBook
        Task<int>  CreateBook(CreateBookRequestDto request);

        // UpdateBook
        Task UpdateBook(int id, UpdateBookRequestDto request);
        // SortBook
        Task SortBook(SortBookRequestDto request);

        // DeleteBook
        Task DeleteBook(int id);
    }
}
