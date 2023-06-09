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
        var connectionString = GetConnectionStringFromEnv();
        if (connectionString is null) { throw new ArgumentNullException(nameof(connectionString)); }
        services.AddSingleton(new SocioFormadorDapperDbContext(connectionString));
        services.AddScoped<ICiudadRepository, CiudadRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        return services;
    }

    private static string GetConnectionStringFromEnv()
    {
        var host = Environment.GetEnvironmentVariable("DBHOST");
        var dbport = Environment.GetEnvironmentVariable("DBPORT");
        var dbname = Environment.GetEnvironmentVariable("DBNAME");
        var user = Environment.GetEnvironmentVariable("DBUSER");
        var password = Environment.GetEnvironmentVariable("DBPASSWORD");
        
        var connectionString = $"Server={host};Port={dbport};Database={dbname};User={user};Password={password};";
        return connectionString;
    }
}
