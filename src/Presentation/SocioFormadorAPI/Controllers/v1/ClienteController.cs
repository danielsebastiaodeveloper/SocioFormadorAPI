using Microsoft.AspNetCore.Mvc;
using SocioFormador.Application.Features.Clientes.Commands.CreateClienteCommand;
using SocioFormador.Application.Features.Clientes.Commands.DeleteClienteCommand;
using SocioFormador.Application.Features.Clientes.Commands.UpdateClienteCommand;
using SocioFormador.Application.Features.Clientes.Queries.GetAllClientes;
using SocioFormador.Application.Features.Clientes.Queries.GetClientById;

namespace SocioFormadorAPI.Controllers.v1;

[ApiVersion("1.0")]
public class ClienteController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateClienteCommand clienteCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(clienteCommand, cancellationToken);
        return CreatedAtRoute("GetClienteById", new { Id = result.Data }, null);
    }

    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var cliente = new GetAllClientesQuery();
        var result = await Mediator.Send(cliente, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{Id}", Name = "GetClienteById")]
    public async Task<IActionResult> GetClienteById(long Id, CancellationToken cancellationToken)
    {
        var cliente = new GetClienteByIdQuery { 
            Id = Id
        };
        var result = await Mediator.Send(cliente, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(long Id, [FromBody] UpdateClienteCommand updateClienteCommand, CancellationToken cancellationToken)
    {   
        if (Id != updateClienteCommand.Id)
        {
            return BadRequest("The Id param is not valid.");
        }

        var result = await Mediator.Send(updateClienteCommand, cancellationToken);

        if (result.Data)
        {
            return NoContent();
        }

        return BadRequest(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(long Id, CancellationToken cancellationToken)
    {
        var cliente = new DeleteClienteCommand
        {
            Id = Id
        };

        var result = await Mediator.Send(cliente, cancellationToken);

        if (result.Data)
        {
            return NoContent();
        }

        return BadRequest(result);
    }
}
