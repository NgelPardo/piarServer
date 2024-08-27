using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Evaluaciones.DeleteEvaluacion;

public sealed record DeleteEvaluacionCommand(Guid Id) : ICommand<Guid>;