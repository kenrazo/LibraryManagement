using LibraryManagement.Domain.Abstractions;

namespace LibraryManagement.Domain.Books
{
    public class BookErrors
    {
        public static Error BookNotFound(int id) => new("Book.NotFound", $"The book with specified id: {id} not found");
    }
}
