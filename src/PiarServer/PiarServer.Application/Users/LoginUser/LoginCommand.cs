using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Users.LoginUser;

public record LoginCommand(string Email, string Password) : ICommand<string>;