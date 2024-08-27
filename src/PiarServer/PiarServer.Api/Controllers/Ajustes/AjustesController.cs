using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.Ajustes.CrearAjuste;
using PiarServer.Application.Ajustes.DeleteAjuste;
using PiarServer.Application.Ajustes.GetAjustes;
using PiarServer.Application.Ajustes.UpdateAjuste;

namespace PiarServer.Api.Controllers.Ajustes;

[ApiController]
[Route("api/ajustes")]
public class AjustesController : ControllerBase
{
    private readonly ISender _sender;

    public AjustesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAjustes(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetAjustesQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);

        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearAjuste(
        CrearAjusteRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearAjusteCommand
        (
            request.id_mat,
            request.desc_ajt,
            request.id_uss,
            request.fec_dil
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(GetAjustes), new { id = resultado.Value }, resultado.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAjuste(
        Guid id,
        [FromBody] UpdateAjusteRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdateAjusteCommand(
            id,
            request.desc_ajt
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAjuste(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteAjusteCommand( id );

        var result = await _sender.Send( command, cancellationToken );

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}