using MediatR;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Clientes.Commands.UpdateClienteCommand;

public class UpdateClienteCommand : IRequest<Response<bool>>
{
    public long Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Email { get; set; }
    public long CiudadId { get; set; }
}


public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<bool>>
{
    private readonly IClienteRepository clientRepository;

    public UpdateClienteCommandHandler(IClienteRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<Response<bool>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente()
        {
            Id = request.Id,
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Email = request.Email,
            CiudadId = request.CiudadId
        };

        var result = await clientRepository.UpdateAsync(cliente, request.Id, cancellationToken);
        return new Response<bool>(result, "Success");
    }
}