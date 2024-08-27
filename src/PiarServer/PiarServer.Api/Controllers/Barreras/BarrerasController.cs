using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.Barreras.CrearBarrera;
using PiarServer.Application.Barreras.DeleteBarrera;
using PiarServer.Application.Barreras.GetBarreras;
using PiarServer.Application.Barreras.UpdateBarrera;

namespace PiarServer.Api.Controllers.Barreras;

[ApiController]
[Route("api/barreras")]
public class BarrerasController : ControllerBase
{
    private readonly ISender _sender;

    public BarrerasController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBarreras(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetBarrerasQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearBarrera(
        CrearBarreraRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearBarreraCommand
        (
            request.id_mat,
            request.desc_barr,
            request.id_uss,
            request.fec_dil
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(GetBarreras), new { id = resultado.Value }, resultado.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBarrera(
        Guid id,
        [FromBody] UpdateBarreraRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdateBarreraCommand(
            id,
            request.desc_barr
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarrera(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteBarreraCommand( id );

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}