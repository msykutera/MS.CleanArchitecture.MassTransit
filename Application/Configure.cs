using System.Reflection;
using MassTransit;

namespace Application;

public static class Configure
{
    public static void AddHandlers(this IBusRegistrationConfigurator config)
    {
        config.AddConsumers(Assembly.GetExecutingAssembly());
    }
}
