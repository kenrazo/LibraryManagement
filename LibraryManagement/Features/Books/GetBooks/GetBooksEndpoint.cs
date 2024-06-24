using LibraryManagement.Application.Book.Queries.GetBooks;
using MediatR;

namespace LibraryManagement.API.Features.Books.GetBooks
{
    public static class GetBooksEndpoint
    {
        public static void MapGetBookEndpoint(this IEndpointRouteBuilder builder)
            => builder.MapGet("books", Get)
            .Produces<IEnumerable<GetBooksResponse>>(StatusCodes.Status200OK);

        private static async Task<IResult> Get(IMediator mediator)
        {
            var result = await mediator.Send(new GetBooksQuery());

            return Results.Ok(result);
        }

    }
}
