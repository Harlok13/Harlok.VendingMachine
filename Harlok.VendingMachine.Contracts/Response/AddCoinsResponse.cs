using Harlok.VendingMachine.Contracts.Base;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Contracts.Response;

public sealed record AddCoinsResponse(
    bool IsSuccess,
    IReadOnlyCollection<Coin> Coins) : IApiResult;