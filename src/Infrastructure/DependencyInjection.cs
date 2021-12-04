using Common;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services
        )
        {
            services.AddTransient<IDateTime, MachineDateTime>();

            return services;
        }
    }
}
