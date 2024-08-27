using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.BarrerasPiar.CrearBarreraPiar;
using PiarServer.Application.BarrerasPiar.DeleteBarreraPiar;
using PiarServer.Application.BarrerasPiar.GetBarrerasPiar;

namespace PiarServer.Api.Controllers.BarrerasPiar;

[ApiController]
[Route("api/barreraspiar")]
public class BarrerasPiarController : ControllerBase
{
    private readonly ISender _sender;
    public BarrerasPiarController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBarrerasPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetBarrerasPiarQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearBarreraPiar(
        Guid id,
        CrearBarreraPiarBatchRequest request,
        CancellationToken cancellationToken
    )
    {
        var results = new List<Guid>();

        foreach (var barrerasPiar in request.BarrerasPiar)
        {
            var command = new CrearBarreraPiarCommand
            (
                barrerasPiar.id_mat,
                barrerasPiar.id_barr,
                barrerasPiar.id_piar,
                barrerasPiar.sem_barr
            );
            
            var resultado = await _sender.Send(command, cancellationToken);

            if(resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            results.Add(resultado.Value);
        }

        return CreatedAtAction(nameof(GetBarrerasPiar), new { id }, results);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarrerasPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteBarreraPiarCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}