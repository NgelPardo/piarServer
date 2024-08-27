using MediatR;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}