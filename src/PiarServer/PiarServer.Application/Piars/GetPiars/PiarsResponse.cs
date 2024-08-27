namespace PiarServer.Application.Piars.GetPiars;

public sealed class PiarsResponse
{
    public Guid id { get; init; }
    public string? NomEst { get; init; }
    public string? DocEst { get; init; }
    public DateTime FecDil { get; init; }
    public int EstPiar { get; init; }
    public string? UltGrado { get; init; }
}