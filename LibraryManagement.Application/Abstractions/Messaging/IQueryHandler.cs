﻿using LibraryManagement.Domain.Abstractions;
using MediatR;

namespace LibraryManagement.Application.Abstractions.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
     where TQuery : IQuery<TResponse>
    {
    }
}
