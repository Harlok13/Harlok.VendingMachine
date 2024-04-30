using Harlok.VendingMachine.Contracts.Base;
using Harlok.VendingMachine.Contracts.Data;
using Harlok.VendingMachine.Domain.Contracts;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Contracts.Response;

public sealed record BuyDrinksResponse(
    IReadOnlyCollection<PurchasedDrink> Drinks,
    IReadOnlyCollection<Coin> OddMoney) : IApiResult;