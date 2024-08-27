namespace PiarServer.Application.Users.GetUsers;

public sealed class UsersResponse
{
    public Guid Id { get; init; }	
    public string? Nombres { get; init; }
    public string? Apellidos { get;  init; }
    public string? Email { get; init; }
    public DateTime? Fec_Dil { get; init; }
    public string? Rol { get; init; }
    public int? Id_Rol { get; init; }
}