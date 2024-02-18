using Book.Service.Interfaces;
using Book.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBookService(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            
            return services;
        }

    }
}
