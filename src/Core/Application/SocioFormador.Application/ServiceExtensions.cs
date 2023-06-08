using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocioFormador.Application.Behaviours;
using System.Reflection;

namespace SocioFormador.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationLayer (this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}
