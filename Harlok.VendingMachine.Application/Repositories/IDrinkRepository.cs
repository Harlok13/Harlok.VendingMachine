using Harlok.VendingMachine.Contracts.Data;

namespace Harlok.VendingMachine.Application.Repositories;

public interface IDrinkRepository
{
    Task<IEnumerable<DrinkDto>> GetAllDrinksAsNoTrackingAsync(CancellationToken cT);
}