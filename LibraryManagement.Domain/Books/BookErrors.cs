using LibraryManagement.Domain.Abstractions;

namespace LibraryManagement.Domain.Books
{
    public class BookErrors
    {
        public static Error BookNotFound(int id)
            => new("Book.NotFound", $"The book with Id: {id} not found.");

        public static Error BookAlreadyExist(string title, string author)
            => new("Book.IsAlreadyExist", $"The book with Title: {title} and Author: {author} already exist.");

    }
}
