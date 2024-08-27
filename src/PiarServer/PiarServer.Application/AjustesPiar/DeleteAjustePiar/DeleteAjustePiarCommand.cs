using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.AjustesPiar.DeleteAjustePiar;

public sealed record DeleteAjustePiarCommand(Guid Id) : ICommand<Guid>;