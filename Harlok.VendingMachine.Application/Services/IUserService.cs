using Harlok.Core.Result;
using Harlok.VendingMachine.Contracts.Request;
using Harlok.VendingMachine.Contracts.Response;

namespace Harlok.VendingMachine.Application.Services;

public interface IUserService
{
    Task<Result<AddCoinResponse>> AddCoinAsync(AddCoinRequest request, CancellationToken cT);

    Task<Result<RemoveCoinResponse>> RemoveCoinAsync(RemoveCoinRequest request, CancellationToken cT);

    Task<Result<GetCoinsResponse>> GetCoinsAsync(CancellationToken cT);

    Task<Result<AddCoinsResponse>> AddCoinsAsync(AddCoinsRequest request, CancellationToken cT);

    Task<Result<ClearCoinsResponse>> ClearCoinsAsync(CancellationToken cT);
}