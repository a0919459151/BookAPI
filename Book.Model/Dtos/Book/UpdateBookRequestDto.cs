namespace Book.Model.Dtos.Book
{
    public class UpdateBookRequestDto
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? AuthorId { get; set; }
    }
}
