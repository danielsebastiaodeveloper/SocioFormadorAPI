using MediatR;
using SocioFormador.Application.Features.Clientes.Commands.UpdateClienteCommand;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Ciudades.Commands.UpdateCiudadCommand;

public class UpdateCiudadCommand : IRequest<Response<bool>>
{
    public long Id { get; set; }
    public required string Nombre { get; set; }
}

public class UpdateCiudadCommandHandler : IRequestHandler<UpdateCiudadCommand, Response<bool>>
{
    private readonly ICiudadRepository ciudadRepository;

    public UpdateCiudadCommandHandler(ICiudadRepository  ciudadRepository)
    {
        this.ciudadRepository = ciudadRepository;
    }

    public async Task<Response<bool>> Handle(UpdateCiudadCommand request, CancellationToken cancellationToken)
    {
        var  ciudad = new Ciudad()
        {
            Id = request.Id,
            Nombre = request.Nombre
        };

        var result = await ciudadRepository.UpdateAsync(ciudad, request.Id, cancellationToken);
        return new Response<bool>(result, "Success");
    }
}
