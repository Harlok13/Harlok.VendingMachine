namespace Harlok.VendingMachine.Domain.Primitives;

public sealed record BuyDrinkInfo(
    string DrinkName,
    short Amount);