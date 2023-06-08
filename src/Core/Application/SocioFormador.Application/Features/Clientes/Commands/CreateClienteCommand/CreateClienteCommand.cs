using MediatR;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Clientes.Commands.CreateClienteCommand;

public class CreateClienteCommand : IRequest<Response<long>>
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public long CiudadId { get; set; }
}

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<long>>
{
    private readonly IClienteRepository clientRepository;

    public CreateClienteCommandHandler(IClienteRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<Response<long>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente(){
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Email = request.Email,
            CiudadId = request.CiudadId    

        };

        var result = await clientRepository.CreateAsync(cliente, cancellationToken);
        return new Response<long>(result, "Success");
    }
}
