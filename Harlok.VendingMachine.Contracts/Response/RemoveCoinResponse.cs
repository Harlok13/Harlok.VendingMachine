using Harlok.VendingMachine.Contracts.Base;

namespace Harlok.VendingMachine.Contracts.Response;

public sealed record RemoveCoinResponse(
    bool IsSuccess,
    Guid CoinId) : IApiResult;

    