using LibraryManagement.API.Features.Books.BorrowBook;
using LibraryManagement.API.Features.Books.CreateBook;
using LibraryManagement.API.Features.Books.GetBooks;
using LibraryManagement.API.Features.Books.ReturnBook;

namespace LibraryManagement.API
{
    public static class APIConfiguration
    {
        public static void AddEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder
                .MapGroup("api")
                .WithTags("Books API");

            group.MapGetBookEndpoint();
            group.MapCreateBookEndpoint();
            group.MapBorrowBookEndpoint();
            group.MapReturnBookEndpoint();
        }
    }
}
