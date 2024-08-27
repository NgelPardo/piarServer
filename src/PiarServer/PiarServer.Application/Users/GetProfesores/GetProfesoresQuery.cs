using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Users.GetUsers;

namespace PiarServer.Application.Users.GetProfesores;

public sealed record GetProfesoresQuery() : IQuery<IReadOnlyList<UsersResponse>>;