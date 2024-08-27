using PiarServer.Domain.Abstractions;

namespace PiarServer.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId, string passwordNoHash) : IDomainEvent;