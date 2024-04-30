using Microsoft.Extensions.DependencyInjection;

namespace Harlok.Core.Extensions;

public static class CoreExtensions
{
    public static IServiceCollection AddMapper<TProfile>(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TProfile));
        
        return services;
    }
}