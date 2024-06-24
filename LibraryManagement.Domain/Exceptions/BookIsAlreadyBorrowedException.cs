using LibraryManagement.Domain.Abstractions;

namespace LibraryManagement.Domain.Exceptions
{
    public class BookIsAlreadyBorrowedException : Exception
    {
        public BookIsAlreadyBorrowedException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; set; }
    }
}
