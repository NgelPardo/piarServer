using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.Objetivos.CrearObjetivo;
using PiarServer.Application.Objetivos.DeleteObjetivo;
using PiarServer.Application.Objetivos.GetObjetivos;
using PiarServer.Application.Objetivos.UpdateObjetivo;

namespace PiarServer.Api.Controllers.Objetivos;

[ApiController]
[Route("api/objetivos")]
public class ObjetivosController : ControllerBase
{
    private readonly ISender _sender;

    public ObjetivosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetObjetivos( 
        Guid id,
        CancellationToken cancellationToken )
    {
        var query = new GetObjetivosQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearObjetivo(
        CrearObjetivoRequest request,
        CancellationToken cancellationToken 
    )
    {
        var command = new CrearObjetivoCommand
        (
            request.id_mat,
            request.desc_obj,
            request.id_uss,
            request.fec_dil
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(GetObjetivos), new { id = resultado.Value }, resultado.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateObjetivo(
        Guid id,
        [FromBody] UpdateObjetivoRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdateObjetivoCommand(
            id,
            request.desc_obj
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteObjetivo(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteObjetivoCommand( id );

        var result = await _sender.Send( command, cancellationToken );

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}