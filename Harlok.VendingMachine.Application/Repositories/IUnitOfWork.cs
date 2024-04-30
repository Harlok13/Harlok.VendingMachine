using Harlok.Core.UnitOfWorkFactory;

namespace Harlok.VendingMachine.Application.Repositories;

public interface IUnitOfWork : IUnitOfWorkFactory
{
    IDrinkRepository DrinkRepository { get; }
    
    IVendingMachineRepository VendingMachineRepository { get; }
    
    IUserRepository UserRepository { get; }
}