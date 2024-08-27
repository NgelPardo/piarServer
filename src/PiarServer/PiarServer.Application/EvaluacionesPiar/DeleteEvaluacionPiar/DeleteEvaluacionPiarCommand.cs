using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.EvaluacionesPiar.DeleteEvaluacionPiar;

public sealed record DeleteEvaluacionPiarCommand(Guid Id) : ICommand<Guid>;