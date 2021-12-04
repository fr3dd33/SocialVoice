using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            string postgresConnectionString
        )
        {
            services.AddDbContext<SocialVoiceDbContext>(options =>
                options.UseNpgsql(postgresConnectionString));

            services.AddScoped<ISocialVoiceDbContext>(provider =>
                provider.GetService<SocialVoiceDbContext>());

            return services;
        }
    }
}
