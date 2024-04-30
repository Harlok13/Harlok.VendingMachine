using Harlok.VendingMachine.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Harlok.VendingMachine.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IVendingMachineService, VendingMachineService>();
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}