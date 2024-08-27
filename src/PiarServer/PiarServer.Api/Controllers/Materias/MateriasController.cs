using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.Materias.CrearMateria;
using PiarServer.Application.Materias.DeleteMateria;
using PiarServer.Application.Materias.GetMaterias;
using PiarServer.Application.Materias.UpdateMateria;

namespace PiarServer.Api.Controllers.Materias;

[ApiController]
[Route("api/materias")]
public class MateriasController : ControllerBase
{

    private readonly ISender _sender;

    public MateriasController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMaterias( 
        Guid id,
        CancellationToken cancellationToken 
    )
    {
        var query = new GetMateriasQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }   

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CrearMateria(
        Guid id,
        MateriaCrearRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearMateriaCommand
        (
            request.id_uss,
            request.id_prof,
            request.nom_mat,
            request.grd_mat,
            request.fec_dil
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(GetMaterias), new {id = resultado.Value}, resultado.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMateria(
        Guid id,
        [FromBody] UpdateMateriaRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdateMateriaCommand(
            id,
            request.nom_mat,
            request.grd_mat,
            request.id_prof
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMateria(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteMateriaCommand( id );

        var result = await _sender.Send( command, cancellationToken );

        if (result.IsFailure){
            return Unauthorized(result.Error);
        }

        return NoContent();
    }

}