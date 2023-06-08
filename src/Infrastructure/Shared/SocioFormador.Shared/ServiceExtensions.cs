using Microsoft.Extensions.DependencyInjection;
using SocioFormador.Domain.Interfaces;
using SocioFormador.Shared.Services;

namespace SocioFormador.Shared;

public static class ServiceExtensions
{
    public static IServiceCollection AddSharedInfraestructure(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeService, DateTimeService>();
        return services;
    }
}
