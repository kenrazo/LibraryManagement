using LibraryManagement.Domain.Books;
using LibraryManagement.Infrastructure.EFCore.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure.EFCore
{
    public static class InfrastructureEFCoreConfiguration
    {
        public static IServiceCollection AddInfrastructureEFCoreConfiguration(this IServiceCollection services)
        {
            return services
                .AddEFCore()
                .AddRepositories();
        }

        private static IServiceCollection AddEFCore(this IServiceCollection services)
        {
            return services.AddDbContext<LibraryManagementContext>(options => options.UseInMemoryDatabase(databaseName: "NoteTaking"));
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
