using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.Users.DeleteUser;
using PiarServer.Application.Users.GetProfesores;
using PiarServer.Application.Users.GetUsers;
using PiarServer.Application.Users.LoginUser;
using PiarServer.Application.Users.RegisterUser;
using PiarServer.Application.Users.UpdateUser;
using PiarServer.Domain.Permissions;
using PiarServer.Infrastructure.Authentication;

namespace PiarServer.Api.Controllers.Users;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new LoginCommand(request.Email, request.Password);
        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    //[HasPermission(PermissionEnum.UpdateUser)]
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterUserRequest request,
        CancellationToken cancelToken
    )
    {
        var command = new RegisterUserCommand(
            request.Email,
            request.Nombre,
            request.Apellido,
            request.Password,
            request.Rol
        );

        var result = await _sender.Send(command, cancelToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetUsuarios(CancellationToken cancellationToken){
        var query = new GetUsersQuery();
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }

    [HttpGet("profesores")]
    public async Task<IActionResult> GetProfesores(CancellationToken cancellationToken)
    {
        var query = new GetProfesoresQuery();
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUsuario(
        Guid id,
        [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdateUserCommand(
            id,
            request.Nombre,
            request.Apellido,
            request.Rol
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteUserCommand( id );

        var result = await _sender.Send( command, cancellationToken );

        if (result.IsFailure){
            return Unauthorized(result.Error);
        }

        return NoContent();
    }

}