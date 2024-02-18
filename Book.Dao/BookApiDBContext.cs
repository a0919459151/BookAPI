using Microsoft.EntityFrameworkCore;
using Book.Model.Entities;
using BookEntity = Book.Model.Entities.Book;

namespace Book.Dao
{
    public class BookApiDBContext : DbContext
    {
        public BookApiDBContext()
        {
        }

        public BookApiDBContext(DbContextOptions<BookApiDBContext> options) : base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookApiDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
