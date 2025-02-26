using BuildingBlocks.Messaging.MassTransit;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices
       (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehaviors<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });


        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

        return services;
    }
}

