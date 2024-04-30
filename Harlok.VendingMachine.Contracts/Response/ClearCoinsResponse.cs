using Harlok.VendingMachine.Contracts.Base;

namespace Harlok.VendingMachine.Contracts.Response;

public sealed record ClearCoinsResponse(
    bool IsSuccess) : IApiResult;