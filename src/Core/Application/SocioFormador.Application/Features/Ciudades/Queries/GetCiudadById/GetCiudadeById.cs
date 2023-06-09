using AutoMapper;
using MediatR;
using SocioFormador.Application.DTOs;
using SocioFormador.Application.Features.Clientes.Queries.GetClientById;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Ciudades.Queries.GetCiudadById;

public class GetCiudadeById: IRequest<Response<CiudadDTO>>
{
    public long Id { get; set; }
}

public class GetCiudadeByIdHandler : IRequestHandler<GetCiudadeById, Response<CiudadDTO>>
{
    private readonly ICiudadRepository ciudadRepository;
    private readonly IMapper mapper;

    public GetCiudadeByIdHandler(ICiudadRepository  ciudadRepository, IMapper mapper)
    {
        this.ciudadRepository = ciudadRepository;
        this.mapper = mapper;
    }

    public async Task<Response<CiudadDTO>> Handle(GetCiudadeById request, CancellationToken cancellationToken)
    {
        var result = await ciudadRepository.GetEntityByIdAsync(request.Id);
        var ciudades = mapper.Map<CiudadDTO>(result);
        var response = new Response<CiudadDTO>(ciudades, "Success");
        return response;
    }
}
