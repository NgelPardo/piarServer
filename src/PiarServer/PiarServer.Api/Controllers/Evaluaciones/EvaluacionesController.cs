using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.Evaluaciones.CrearEvaluacion;
using PiarServer.Application.Evaluaciones.DeleteEvaluacion;
using PiarServer.Application.Evaluaciones.GetEvaluaciones;
using PiarServer.Application.Evaluaciones.UpdateEvaluacion;

namespace PiarServer.Api.Controllers.Evaluaciones;

[ApiController]
[Route("api/evaluaciones")]
public class EvaluacionesController : ControllerBase
{
    private readonly ISender _sender;

    public EvaluacionesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvaluaciones(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetEvaluacionesQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearEvaluacion(
        CrearEvaluacionRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearEvaluacionCommand
        (
            request.id_mat,
            request.desc_eva,
            request.id_uss,
            request.fec_dil
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(GetEvaluaciones), new { id = resultado.Value }, resultado.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvaluacion(
        Guid id,
        [FromBody] UpdateEvaluacionRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdateEvaluacionCommand(
            id,
            request.desc_eva
        );

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvaluacion(
        Guid id,
        CancellationToken cancellationToken    
    )
    {
        var command =  new DeleteEvaluacionCommand( id );

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure){
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}