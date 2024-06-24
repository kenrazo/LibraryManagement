using LibraryManagement.Domain.Abstractions;

namespace LibraryManagement.Domain.Exceptions
{
    public class BookIsAlreadyReturnedException : Exception
    {
        public BookIsAlreadyReturnedException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; set; }
    }
}
