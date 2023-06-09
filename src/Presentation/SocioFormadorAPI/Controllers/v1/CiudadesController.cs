using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocioFormador.Application.Features.Ciudades.Commands.CreateCiudadCommand;
using SocioFormador.Application.Features.Ciudades.Commands.DeleteCiudadCommand;
using SocioFormador.Application.Features.Ciudades.Commands.UpdateCiudadCommand;
using SocioFormador.Application.Features.Ciudades.Queries.GetAllCiudades;
using SocioFormador.Application.Features.Ciudades.Queries.GetCiudadById;
using SocioFormador.Application.Features.Clientes.Commands.CreateClienteCommand;
using SocioFormador.Application.Features.Clientes.Commands.DeleteClienteCommand;
using SocioFormador.Application.Features.Clientes.Commands.UpdateClienteCommand;
using SocioFormador.Application.Features.Clientes.Queries.GetAllClientes;
using SocioFormador.Application.Features.Clientes.Queries.GetClientById;

namespace SocioFormadorAPI.Controllers.v1
{

    [ApiVersion("1.0")]
    public class CiudadesController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateCiudadCommand createCiudadCommand, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(createCiudadCommand, cancellationToken);
            return CreatedAtRoute("GetCiudadById", new { Id = result.Data }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var cliente = new GetAllCiudadesQuery();
            var result = await Mediator.Send(cliente, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{Id}", Name = "GetCiudadById")]
        public async Task<IActionResult> GetCiudadById(long Id, CancellationToken cancellationToken)
        {
            var cliente = new GetCiudadeById
            {
                Id = Id
            };
            var result = await Mediator.Send(cliente, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, [FromBody] UpdateCiudadCommand updateCiudadCommand, CancellationToken cancellationToken)
        {
            if (Id != updateCiudadCommand.Id)
            {
                return BadRequest("The Id param is not valid.");
            }

            var result = await Mediator.Send(updateCiudadCommand, cancellationToken);

            if (result.Data)
            {
                return NoContent();
            }

            return BadRequest(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id, CancellationToken cancellationToken)
        {
            var ciudad = new DeleteCiudadCommand
            {
                Id = Id
            };

            var result = await Mediator.Send(ciudad, cancellationToken);

            if (result.Data)
            {
                return NoContent();
            }

            return BadRequest(result);
        }
    }
}
