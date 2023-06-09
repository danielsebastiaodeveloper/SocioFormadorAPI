using MediatR;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Ciudades.Commands.CreateCiudadCommand;

public class CreateCiudadCommand:  IRequest<Response<long>>
{
    public string Nombre { get; set; } = default!;
}

public class CreateCiudadCommandHandler : IRequestHandler<CreateCiudadCommand, Response<long>>
{
    private readonly ICiudadRepository ciudadRepository;

    public CreateCiudadCommandHandler(ICiudadRepository ciudadRepository)
    {
        this.ciudadRepository = ciudadRepository;
    }
    public async Task<Response<long>> Handle(CreateCiudadCommand request, CancellationToken cancellationToken)
    {
        var ciudad = new Ciudad()
        {
            Nombre = request.Nombre

        };
        var result = await ciudadRepository.CreateAsync(ciudad, cancellationToken);
        return new Response<long>(result, "Success");
    }
}
