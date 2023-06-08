using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocioFormador.Domain.Interfaces.Repositories;
using SocioFormador.Persistence.Context;
using SocioFormador.Persistence.Repositories;

namespace SocioFormador.Persistence;

public static class DependencyContainer
{

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultMySQL");
        if (connectionString is null) { throw new ArgumentNullException(nameof(connectionString)); }
        services.AddSingleton(new SocioFormadorDapperDbContext(connectionString));
        services.AddScoped<ICiudadRepository, CiudadRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        return services;
    }
}