

using AutoMapper;
using SocioFormador.Application.DTOs;
using SocioFormador.Application.Features.Ciudades.Commands.CreateCiudadCommand;
using SocioFormador.Application.Features.Ciudades.Commands.UpdateCiudadCommand;
using SocioFormador.Application.Features.Clientes.Commands.CreateClienteCommand;
using SocioFormador.Application.Features.Clientes.Commands.UpdateClienteCommand;
using SocioFormador.Domain.Entities;

namespace SocioFormador.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        #region Commands

        CreateMap<CreateClienteCommand, Cliente>();
        CreateMap<UpdateClienteCommand, Cliente>();

        CreateMap<CreateCiudadCommand, Ciudad>();
        CreateMap<UpdateCiudadCommand, Ciudad>();

        #endregion

        #region DTOs

        CreateMap<Cliente, ClienteDTO>();
        CreateMap<Ciudad, CiudadDTO>();

        #endregion
    }
}
