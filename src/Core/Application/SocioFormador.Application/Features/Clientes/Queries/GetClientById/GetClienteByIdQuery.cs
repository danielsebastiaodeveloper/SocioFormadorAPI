using AutoMapper;
using MediatR;
using SocioFormador.Application.DTOs;
using SocioFormador.Application.Features.Clientes.Queries.GetAllClientes;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Clientes.Queries.GetClientById;

public class GetClienteByIdQuery: IRequest<Response<ClienteDTO>>
{
    public long Id { get; set; }
}


public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Response<ClienteDTO>>
{
    private readonly IClienteRepository clienteRepository;
    private readonly IMapper mapper;

    public GetClienteByIdQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
    }

    public async Task<Response<ClienteDTO>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await clienteRepository.GetEntityByIdAsync(request.Id);
        var clientes = mapper.Map<ClienteDTO>(result);
        var response = new Response<ClienteDTO>(clientes, "Success");
        return response;
    }
}
