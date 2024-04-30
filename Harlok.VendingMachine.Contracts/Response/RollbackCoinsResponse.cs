using Harlok.VendingMachine.Contracts.Base;

namespace Harlok.VendingMachine.Contracts.Response;

public sealed record RollbackCoinsResponse(
    ) : IApiResult;