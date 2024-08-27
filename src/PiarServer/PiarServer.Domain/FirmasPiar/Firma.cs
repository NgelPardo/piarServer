namespace PiarServer.Domain.FirmasPiar;

public record Firma(
    int SecPiar,
    byte[] FilePiar,
    string NomFir,
    string AreFir
);