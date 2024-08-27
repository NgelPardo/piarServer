using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.MateriasPiar.CrearMateriaPiar;
using PiarServer.Application.MateriasPiar.DeleteMateriaPiar;
using PiarServer.Application.MateriasPiar.GetMateriasPiar;

namespace PiarServer.Api.Controllers.MateriasPiar;

[ApiController]
[Route("api/materiaspiar")]
public class MateriasPiarController : ControllerBase
{
    private readonly ISender _sender;

    public MateriasPiarController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMateriasPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetMateriasPiarQuery(id);
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CrearMateriasPiar(
        Guid id,
        MateriaPiarCrearBatchRequest request,
        CancellationToken cancellationToken
    )
    {
        var results = new List<Guid>();

        foreach (var materiaPiar in request.MateriasPiar)
        {
            var command = new CrearMateriaPiarCommand(
                materiaPiar.id_piar,
                materiaPiar.id_mat,
                materiaPiar.sem_mat
            );

            var resultado = await _sender.Send(command, cancellationToken);

            if(resultado.IsFailure)
            {
                return Unauthorized(resultado.Error);
            }

            results.Add(resultado.Value);
        }

        return CreatedAtAction(nameof(GetMateriasPiar), new { id }, results);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMateriaPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteMateriaPiarCommand( id );

        var result = await _sender.Send( command, cancellationToken );

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return NoContent();
    }
}