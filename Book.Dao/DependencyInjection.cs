using Book.Dao.Interfaces;
using Book.Dao.Repositories;
using Book.Dao.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Dao
{
    public static class DependencyInjection
    {
        // Add book dao
        public static IServiceCollection AddBookDao(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnection");
            // Add db context
            services.AddDbContext<BookApiDBContext>(options =>
                options.UseSqlite(connectionString));
            // Add repositories
            services.AddRepository();
            return services;
        }

        // Add repositories
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookReposotory, BookReposotory>();
            return services;
        }
    }
}
