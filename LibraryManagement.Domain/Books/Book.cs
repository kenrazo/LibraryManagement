using Ardalis.GuardClauses;
using LibraryManagement.Domain.Abstractions;
using LibraryManagement.Domain.Exceptions;
namespace LibraryManagement.Domain.Books
{
    public class Book
    {
        public int Id { get; init; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public bool IsBorrowed { get; private set; }

        private Book() { }

        // Private constructor for creating a new Book entity
        private Book(string title, string author, string isbn, bool isBorrowed)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = isBorrowed;
        }

        // Factory method to create a new Book
        public static Book CreateNewBook(string title, string author, string isbn)
        {
            Guard.Against.NullOrEmpty(title);
            Guard.Against.NullOrEmpty(author);

            return new Book(title, author, isbn, isBorrowed: false);
        }

        // Method to mark the book as borrowed
        public void BarrowBook()
        {
            if (IsBorrowed)
            {
                ThrowBookIsAlreadyBorrowedException();
                return;
            }

            IsBorrowed = true;
        }

        // Method to mark the book as returned
        public void ReturnBook()
        {
            if (!IsBorrowed)
            {
                ThrowBookIsAlreadyReturnedException();
            }

            IsBorrowed = false;
        }

        private void ThrowBookIsAlreadyBorrowedException()
        {
            List<ValidationError> errors = new()
                {
                    new ValidationError(string.Empty,
                        $"The book with Title: {Title} is already barrowed.")
                };
            throw new BookIsAlreadyBorrowedException(errors);
        }

        private void ThrowBookIsAlreadyReturnedException()
        {
            List<ValidationError> errors = new()
                {
                    new ValidationError(string.Empty,
                        $"The book with Title: {Title} is already returned.")
                };
            throw new BookIsAlreadyReturnedException(errors);
        }
    }



}
