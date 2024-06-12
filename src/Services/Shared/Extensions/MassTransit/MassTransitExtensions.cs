using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions.MassTransit;

public static class MassTransitExtensions
{
    public static IServiceCollection AddConfiguredMassTransit(this IServiceCollection services, Assembly assembly)
    {
        services.AddMassTransit(opt =>
        {
            opt.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("dev"));
            opt.AddConsumers(assembly);
            opt.UsingRabbitMq((ctx, cnf) =>
            {
                cnf.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cnf.ConfigureEndpoints(ctx);
            });
        });
        
        return services;
    }
}