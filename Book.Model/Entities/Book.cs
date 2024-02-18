namespace Book.Model.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int Sort { get; set; }


        public int? AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}
