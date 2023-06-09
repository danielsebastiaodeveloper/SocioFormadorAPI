using MediatR;
using SocioFormador.Application.Features.Clientes.Commands.DeleteClienteCommand;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Ciudades.Commands.DeleteCiudadCommand;

public class DeleteCiudadCommand:  IRequest<Response<bool>>
{
    public long Id { get; set; }
}

public class DeleteCiudadCommandHandler : IRequestHandler<DeleteCiudadCommand, Response<bool>>
{
    private readonly ICiudadRepository ciudadRepository;

    public DeleteCiudadCommandHandler(ICiudadRepository ciudadRepository)
    {
        this.ciudadRepository = ciudadRepository;
    }
    public async Task<Response<bool>> Handle(DeleteCiudadCommand request, CancellationToken cancellationToken)
    {
        var result = await ciudadRepository.DeleteAsync(request.Id, cancellationToken);
        return new Response<bool>(result, string.Empty);
    }
}
