﻿using LibraryManagement.Application.Books.Commands.ReturnBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Features.Books.ReturnBook
{
    public static class ReturnBookEndpoint
    {
        public static void MapReturnBookEndpoint(this IEndpointRouteBuilder builder)
            => builder.MapPut("books/{id}/return", ReturnBook)
                .Produces<ReturnBookResponse>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);

        private static async Task<IResult> ReturnBook(IMediator mediator, int id)
        {
            var result = await mediator.Send(new ReturnBookCommand { Id = id });

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

            return Results.Ok(result.Value);
        }
    }
}
