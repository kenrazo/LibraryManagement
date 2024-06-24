using LibraryManagement.Application.Book.Commands.CreateBook;
using MediatR;

namespace LibraryManagement.API.Features.Books.CreateBook
{
    public static class CreateBookEndpoint
    {
        public static void MapCreateBookEndpoint(this IEndpointRouteBuilder builder)
            => builder.MapPost("books", CreateBook);

        public static async Task<IResult> CreateBook(IMediator mediator, CreateBookCommand command)
        {
            var result = await mediator.Send(command);

            return Results.Ok(result);
        }
    }
}
