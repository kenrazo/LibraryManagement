using LibraryManagement.Application.Abstractions.Messaging;

namespace LibraryManagement.Application.Book.Commands.BorrowBook
{
    public class BorrowBookCommand : ICommand<BorrowBookResponse>
    {
        public int Id { get; set; }
    }
}
