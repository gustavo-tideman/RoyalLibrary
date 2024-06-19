using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Infra.Concretes;
using RoyalLibrary.Repositories.Interfaces;
using RoyalLibrary.Repositories.Repository;
using RoyalLibrary.Services;
using RoyalLibrary.Services.Interfaces;

namespace RoyalLibrary.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterDbContext(this IServiceCollection services, string connectionString) => services.AddDbContext<IRoyalLibraryDbContext, Context>(options => options.UseSqlServer(connectionString));

        public static void RegisterInfra(this IServiceCollection services) => services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void RegisterRepositories(this IServiceCollection services) => services.AddScoped<IBookRepository, BookRepository>();

        public static void RegisterServices(this IServiceCollection services) => services.AddScoped<IBookService, BookService>();
    }
}
