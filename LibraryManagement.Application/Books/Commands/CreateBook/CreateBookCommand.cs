using LibraryManagement.Application.Abstractions.Messaging;
using LibraryManagement.Application.Books.Common;

namespace LibraryManagement.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : BookModel, ICommand<CreateBookResponse>
    {
    }
}
