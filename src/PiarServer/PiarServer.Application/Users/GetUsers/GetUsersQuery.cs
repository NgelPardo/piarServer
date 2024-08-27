using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Users.GetUsers;
public sealed record GetUsersQuery() : IQuery<IReadOnlyList<UsersResponse>>;