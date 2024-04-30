using Harlok.Core.UnitOfWorkFactory;
using Harlok.VendingMachine.Application.Repositories;
using Harlok.VendingMachine.Infrastructure.DAL.Context;
using Microsoft.Extensions.Logging;

namespace Harlok.VendingMachine.Infrastructure.DAL.UoW;

public class UnitOfWork : UnitOfWorkFactory<VendingMachineContext>, IUnitOfWork
{
    public UnitOfWork(VendingMachineContext context, ILogger<VendingMachineContext> logger) 
        : base(context, logger)
    {
    }

    public IDrinkRepository DrinkRepository => new DrinkRepository<VendingMachineContext>(Context);
    public IVendingMachineRepository VendingMachineRepository => new VendingMachineRepository<VendingMachineContext>(Context);
    public IUserRepository UserRepository => new UserRepository<VendingMachineContext>(Context);
}