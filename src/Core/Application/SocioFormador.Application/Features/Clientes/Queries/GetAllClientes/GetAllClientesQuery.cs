using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using SocioFormador.Application.DTOs;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocioFormador.Application.Features.Clientes.Queries.GetAllClientes
{
    public class GetAllClientesQuery : IRequest<Response<IEnumerable<ClienteDTO>>>
    {

    }

    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, Response<IEnumerable<ClienteDTO>>>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public GetAllClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<Response<IEnumerable<ClienteDTO>>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            var result = await clienteRepository.GetAllAsync();
            var clientes = mapper.Map<List<ClienteDTO>>(result);
            var response = new Response<IEnumerable<ClienteDTO>>(clientes, "Success");
            return response;
        }
    }

}