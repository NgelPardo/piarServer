using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.EvaluacionesPiar.CrearEvaluacionPiar;
using PiarServer.Application.EvaluacionesPiar.DeleteEvaluacionPiar;
using PiarServer.Application.EvaluacionesPiar.GetEvaluacionesPiar;

namespace PiarServer.Api.Controllers.EvaluacionesPiar;

[ApiController]
[Route("api/evaluacionespiar")]
public class EvaluacionesPiarController : ControllerBase
{
    private readonly ISender _sender;

    public EvaluacionesPiarController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvaluacionesPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetEvaluacionesPiarQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearEvaluacionPiar(
        Guid id,
        CrearEvaluacionPiarBatchRequest request,
        CancellationToken cancellationToken
    )
    {
        var results = new List<Guid>();

        foreach (var evaluacionPiar in request.EvaluacionesPiar)
        {
            var command = new CrearEvaluacionPiarCommand
            (
                evaluacionPiar.id_mat,
                evaluacionPiar.id_eva,
                evaluacionPiar.id_piar,
                evaluacionPiar.sem_eva
            );

            var resultado = await _sender.Send(command, cancellationToken);

            if(resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }
            
            results.Add(resultado.Value);
        }

        return CreatedAtAction(nameof(GetEvaluacionesPiar), new { id }, results);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvaluacionPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteEvaluacionPiarCommand( id );

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}