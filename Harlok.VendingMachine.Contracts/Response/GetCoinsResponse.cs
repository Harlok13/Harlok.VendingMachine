using Harlok.VendingMachine.Contracts.Base;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Contracts.Response;

public sealed record GetCoinsResponse(
    IEnumerable<Coin> Coins) : IApiResult;