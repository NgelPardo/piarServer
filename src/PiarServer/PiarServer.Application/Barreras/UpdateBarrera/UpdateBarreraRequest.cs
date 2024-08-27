namespace PiarServer.Application.Barreras.UpdateBarrera;

public record UpdateBarreraRequest(
    Guid id,
    string desc_barr
);