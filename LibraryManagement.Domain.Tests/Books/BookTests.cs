using FluentAssertions;
using LibraryManagement.Domain.Books;
using LibraryManagement.Domain.Exceptions;

namespace LibraryManagement.Domain.Tests.Books
{
    public class BookTests
    {
        [Theory]
        [InlineData("The Game", "Neil Strauss", "Is BN")]
        public void Book_CreateNewBook_Success(string title, string author, string isbn)
        {
            var book = Book.CreateNewBook(title, author, isbn);

            book.Should().NotBeNull();
            book.Title.Should().Be(title);
            book.Author.Should().Be(author);
            book.ISBN.Should().Be(isbn);
            book.IsBorrowed.Should().BeFalse();
        }

        [Theory]
        [InlineData("", "Neil Strauss", "Is BN")]
        public void Book_CreateNewBook_ThrowArgumentException_When_Title_IsNull(string title, string author, string isbn)
        {
            Action act = () => { var book = Book.CreateNewBook(title, author, isbn); };

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("The Game", "", "Is BN")]
        public void Book_CreateNewBook_ThrowArgumentException_When_Author_IsNull(string title, string author, string isbn)
        {
            Action act = () => { var book = Book.CreateNewBook(title, author, isbn); };

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("The Game", "Neil Strauss", "Is BN")]
        public void Book_BorrowBook_Success(string title, string author, string isbn)
        {
            var book = Book.CreateNewBook(title, author, isbn);

            book.BarrowBook();

            book.IsBorrowed.Should().BeTrue();
        }

        [Theory]
        [InlineData("The Game", "Neil Strauss", "Is BN")]
        public void Book_BorrowBook_ThatIsAlreadyBorrowed_ThrowException(string title, string author, string isbn)
        {
            var book = Book.CreateNewBook(title, author, isbn);

            book.BarrowBook();

            Action act = () => { book.BarrowBook(); };

            act.Should().Throw<BookIsAlreadyBorrowedException>();
        }

        [Theory]
        [InlineData("The Game", "Neil Strauss", "Is BN")]
        public void Book_ReturnBook_Success(string title, string author, string isbn)
        {
            var book = Book.CreateNewBook(title, author, isbn);

            book.BarrowBook();
            book.ReturnBook();

            book.IsBorrowed.Should().BeFalse();
        }

        [Theory]
        [InlineData("The Game", "Neil Strauss", "Is BN")]
        public void Book_ReturnBook_ThatIsAlreadyReturned_ThrowException(string title, string author, string isbn)
        {
            var book = Book.CreateNewBook(title, author, isbn);

            Action act = () => { book.ReturnBook(); };

            act.Should().Throw<BookIsAlreadyReturnedException>();
        }
    }
}
