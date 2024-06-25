using LibraryManagement.Application.Books.Commands.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Features.Books.CreateBook
{
    public static class CreateBookEndpoint
    {
        public static void MapCreateBookEndpoint(this IEndpointRouteBuilder builder)
            => builder.MapPost("books", CreateBook)
                .Produces<CreateBookResponse>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);

        public static async Task<IResult> CreateBook(IMediator mediator, CreateBookCommand command)
        {
            var result = await mediator.Send(command);

            return Results.Ok(result);
        }
    }
}
