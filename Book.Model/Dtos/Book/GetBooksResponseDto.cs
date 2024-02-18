namespace Book.Model.Dtos.Book
{
    public class GetBooksResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? AuthorId { get; set; }
    }
}
