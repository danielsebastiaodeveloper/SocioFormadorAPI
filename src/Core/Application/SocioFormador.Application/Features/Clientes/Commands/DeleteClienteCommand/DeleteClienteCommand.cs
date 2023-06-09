using MediatR;
using SocioFormador.Application.Wrappers;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocioFormador.Application.Features.Clientes.Commands.DeleteClienteCommand;

public class DeleteClienteCommand : IRequest<Response<bool>>
{
    public long Id { get; set; }
}

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<bool>>
{
    private readonly IClienteRepository clientRepository;

    public DeleteClienteCommandHandler(IClienteRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<Response<bool>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var result = await clientRepository.DeleteAsync(request.Id, cancellationToken);
        return new Response<bool>(result, string.Empty);
    }
}