using LibraryManagement.Application.Abstractions.Messaging;

namespace LibraryManagement.Application.Books.Commands.BorrowBook
{
    public class BorrowBookCommand : ICommand<BorrowBookResponse>
    {
        public int Id { get; set; }
    }
}
