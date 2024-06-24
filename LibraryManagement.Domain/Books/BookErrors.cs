using LibraryManagement.Domain.Abstractions;

namespace LibraryManagement.Domain.Books
{
    public class BookErrors
    {
        public static Error BookNotFound(int id) => new("Book.NotFound", $"The book with specified id: {id} not found");

        public static Error BookIsAlreadyBarrowed(string title) => new("BarrowBook.AlreadyBarrowed", $"The book with Title: {title} is already barrowed");

        public static Error BookIsAlreadyReturned(string title) => new("ReturnBook.NotBarrowed", $"The book with Title: {title} not barrowed");
    }
}
