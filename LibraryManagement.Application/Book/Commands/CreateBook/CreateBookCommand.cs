using LibraryManagement.Application.Abstractions.Messaging;
using LibraryManagement.Application.Book.Common;

namespace LibraryManagement.Application.Book.Commands.CreateBook
{
    public class CreateBookCommand : BookModel, ICommand<CreateBookResponse>
    {
    }
}
