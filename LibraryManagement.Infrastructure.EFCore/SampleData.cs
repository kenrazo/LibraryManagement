using LibraryManagement.Domain.Books;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure.EFCore
{
    public class SampleData
    {
        public static void Initialize(Microsoft.AspNetCore.Builder.IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<LibraryManagementContext>();

            context.Books.AddRange(
                Book.CreateNewBook("title", "author", "isbn"));

            context.SaveChanges();

            var a = context.Books.ToList();
        }

    }
}
