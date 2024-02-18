namespace Book.Model.Dtos.Book
{
    public class GetBooksResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int? Sort { get; set; }
    }
}
