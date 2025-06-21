
using Microsoft.Extensions.DependencyInjection;

namespace DIFAChat.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories (implement interface from Core)
            //services.AddScoped<IUserRepository, UserRepository>();

            // Application Services


            // Any other third-party integrations or utilities
            // services.AddSingleton<ISmsSender, TwilioSmsSender>();

            return services;
        }
    }
}
