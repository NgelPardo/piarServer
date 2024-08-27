using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.ObjetivosPiar.CrearObjetivoPiar;
using PiarServer.Application.ObjetivosPiar.DeleteObjetivoPiar;
using PiarServer.Application.ObjetivosPiar.GetObjetivosPiar;

namespace PiarServer.Api.Controllers.ObjetivosPiar;

[ApiController]
[Route("api/objetivospiar")]
public class ObjetivosPiarController : ControllerBase
{
    private readonly ISender _sender;

    public ObjetivosPiarController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetObjetivosPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetObjetivosPiarQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearObjetivoPiar(
        Guid id,
        CrearObjetivoPiarBatchRequest request,
        CancellationToken cancellationToken
    )
    {
        var results = new List<Guid>();

        foreach (var objetivoPiar in request.ObjetivosPiar)
        {
            var command = new CrearObjetivoPiarCommand
            (
                objetivoPiar.id_mat,
                objetivoPiar.id_obj,
                objetivoPiar.id_piar,
                objetivoPiar.sem_obj
            );
            
            var resultado =  await _sender.Send(command, cancellationToken);
        
            if(resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            results.Add(resultado.Value);
        }

        return CreatedAtAction(nameof(GetObjetivosPiar), new { id }, results);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteObjetivoPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteObjetivoPiarCommand( id );

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}