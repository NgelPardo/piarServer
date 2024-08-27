using MediatR;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
    
}