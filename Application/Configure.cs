using System.Reflection;
using MassTransit;

namespace Microsoft.Extensions.DependencyInjection;

public static class Configure
{
    public static void AddHandlers(this IBusRegistrationConfigurator config)
    {
        config.AddConsumers(Assembly.GetExecutingAssembly());
    }
}
