using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Domain.Contracts;

public sealed record SuccessPurchasedDrinks(
    IReadOnlyCollection<Coin> OddMoney,
    IReadOnlyCollection<PurchasedDrink> Drinks);