namespace Harlok.VendingMachine.Domain.Contracts;

public sealed record PurchasedDrink(
    string Name,
    short Amount);