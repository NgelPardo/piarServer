namespace PiarServer.Application.Objetivos.UpdateObjetivo;

public record UpdateObjetivoRequest(
    Guid id,
    string desc_obj
);