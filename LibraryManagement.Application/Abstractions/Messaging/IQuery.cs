using LibraryManagement.Domain.Abstractions;
using MediatR;

namespace LibraryManagement.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
