using LibraryManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Infrastructures
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private const string EXCEPTION_DETAIL = "One or more validation errors has occurred";
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var exceptionDetails = GetExceptionDetails(exception);

            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail,
            };

            if (exceptionDetails.Errors is not null)
            {
                problemDetails.Extensions["errors"] = exceptionDetails.Errors;
            }

            httpContext.Response.StatusCode = exceptionDetails.Status;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private static ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validation error",
                    EXCEPTION_DETAIL,
                    validationException.Errors),
                BookIsAlreadyBorrowedException isAlreadyBorrowedException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validation Error",
                    isAlreadyBorrowedException.Errors.Select(m => m.ErrorMessage).FirstOrDefault() ?? EXCEPTION_DETAIL,
                    null),
                BookIsAlreadyReturnedException isAlreadyReturnedException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validation Error",
                    isAlreadyReturnedException.Errors.Select(m => m.ErrorMessage).FirstOrDefault() ?? EXCEPTION_DETAIL,
                    null),
                _ => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                    "Server error",
                    exception.Message,
                    null)
            };
        }
    }

    internal record ExceptionDetails(
    int Status,
    string Type,
    string Title,
    string Detail,
    IEnumerable<object>? Errors);
}
