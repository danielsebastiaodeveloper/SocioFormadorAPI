using AutoMapper;
using MediatR;
using SocioFormador.Application.DTOs;
using SocioFormador.Application.Features.Clientes.Queries.GetAllClientes;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Interfaces.Repositories;

namespace SocioFormador.Application.Features.Ciudades.Queries.GetAllCiudades;

public class GetAllCiudadesQuery : IRequest<Response<IEnumerable<CiudadDTO>>>
{
}

public class GetAllCiudadesQueryHandler : IRequestHandler<GetAllCiudadesQuery, Response<IEnumerable<CiudadDTO>>>
{
    private readonly ICiudadRepository ciudadRepository;
    private readonly IMapper mapper;

    public GetAllCiudadesQueryHandler(ICiudadRepository ciudadRepository, IMapper mapper)
    {
        this.ciudadRepository = ciudadRepository;
        this.mapper = mapper;
    }

    public async Task<Response<IEnumerable<CiudadDTO>>> Handle(GetAllCiudadesQuery request, CancellationToken cancellationToken)
    {
        var result = await ciudadRepository.GetAllAsync();
        var ciudades = mapper.Map<List<CiudadDTO>>(result);
        var response = new Response<IEnumerable<CiudadDTO>>(ciudades, "Success");
        return response;
    }
}