using Harlok.VendingMachine.Infrastructure.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Harlok.VendingMachine.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VendingMachineContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("VendingMachineDb")));
        
        return services;
    }
}