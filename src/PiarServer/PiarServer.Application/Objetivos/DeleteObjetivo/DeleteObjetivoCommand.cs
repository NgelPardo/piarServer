
using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Objetivos.DeleteObjetivo;

public sealed record DeleteObjetivoCommand(Guid Id) : ICommand<Guid>;