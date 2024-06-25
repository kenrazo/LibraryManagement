using LibraryManagement.Application.Abstractions.Messaging;

namespace LibraryManagement.Application.Books.Commands.ReturnBook
{
    public class ReturnBookCommand : ICommand<ReturnBookResponse>
    {
        public int Id { get; set; }
    }
}
