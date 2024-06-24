
using LibraryManagement.Application.Book.Commands.BorrowBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Features.Books.BorrowBook
{
    public static class BorrowBookEndpoint
    {
        public static void MapBorrowBookEndpoint(this IEndpointRouteBuilder builder)
            => builder.MapPut("books/{id}/borrow", BorrowBook)
                .Produces<BorrowBookResponse>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);

        private static async Task<IResult> BorrowBook(IMediator mediator, int id)
        {
            var result = await mediator.Send(new BorrowBookCommand { Id = id });

            if (result.IsFailure)
            {
                return Results.BadRequest(new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = result.Error.Code,
                    Title = result.Error.Code,
                    Detail = result.Error.Name,
                });
            }

            return Results.Ok(result);
        }
    }
}
