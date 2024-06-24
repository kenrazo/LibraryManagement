using LibraryManagement.Application.Abstractions.Messaging;

namespace LibraryManagement.Application.Book.Commands.ReturnBook
{
    public class ReturnBookCommand : ICommand<ReturnBookResponse>
    {
        public int Id { get; set; }
    }
}
