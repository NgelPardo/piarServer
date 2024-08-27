using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.AjustesPiar.CrearAjustePiar;
using PiarServer.Application.AjustesPiar.DeleteAjustePiar;
using PiarServer.Application.AjustesPiar.GetAjustesPiar;

namespace PiarServer.Api.Controllers.AjustesPiar;

[ApiController]
[Route("api/ajustespiar")]
public class AjustesPiarController : ControllerBase
{
    private readonly ISender _sender;

    public AjustesPiarController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAjustesPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetAjustesPiarQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearAjustePiar(
        Guid id,
        CrearAjustePiarBatchRequest request,
        CancellationToken cancellationToken
    )
    {
        var results = new List<Guid>();

        foreach (var ajustePiar in request.AjustesPiar)
        {
            var command = new CrearAjustePiarCommand
            (
                ajustePiar.id_mat,
                ajustePiar.id_ajt,
                ajustePiar.id_piar,
                ajustePiar.sem_ajt
            );

            var resultado = await _sender.Send(command, cancellationToken);

            if(resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }
            
            results.Add(resultado.Value);
        }

        return CreatedAtAction(nameof(GetAjustesPiar), new { id }, results);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAjustesPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteAjustePiarCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}