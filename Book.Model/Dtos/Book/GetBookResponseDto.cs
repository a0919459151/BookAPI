namespace Book.Model.Dtos.Book
{
    public class GetBookResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? AuthorId { get; set; }
    }
}
