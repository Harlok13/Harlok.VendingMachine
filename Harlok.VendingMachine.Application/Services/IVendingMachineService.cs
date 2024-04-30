using Harlok.Core.Result;
using Harlok.VendingMachine.Contracts.Request;
using Harlok.VendingMachine.Contracts.Response;

namespace Harlok.VendingMachine.Application.Services;

public interface IVendingMachineService
{
    Task<Result<GetAllDrinksResponse>> GetAllDrinksAsync(CancellationToken cT);
    
    Task<Result<BuyDrinksResponse>> BuyDrinksAsync(BuyDrinksRequest request, CancellationToken cT);
    
    Task<Result<DepositCoinResponse>> DepositCoinAsync(DepositCoinRequest request, CancellationToken cT);
    
    Task<Result<RollbackCoinsResponse>> RollbackCoinsAsync(RollbackCoinsRequest request, CancellationToken cT);
}