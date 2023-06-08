using Microsoft.AspNetCore.Mvc;
using SocioFormador.Application.Features.Clientes.Commands.CreateClienteCommand;

namespace SocioFormadorAPI.Controllers.v1;

[ApiVersion("1.0")]
public class ClienteController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateClienteCommand clienteCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(clienteCommand, cancellationToken);
        return Ok(result);
    }
}
