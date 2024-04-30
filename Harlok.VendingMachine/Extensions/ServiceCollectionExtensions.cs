using Harlok.VendingMachine.Configurations;

namespace Harlok.VendingMachine.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorsWithOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var corsConfig = configuration.GetSection("Cors").Get<CorsConfig>();
        if (corsConfig is null)
            throw new Exception("Cors config is null");
        
        services.AddCors(options =>
            options.AddPolicy(corsConfig.PolicyName, builder => builder
                .WithOrigins(corsConfig.Origins)
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()));
        
        return services;
    }
}