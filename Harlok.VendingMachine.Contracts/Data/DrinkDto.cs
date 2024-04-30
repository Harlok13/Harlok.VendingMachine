namespace Harlok.VendingMachine.Contracts.Data;

public sealed record DrinkDto(
    long Id,
    string Name,
    decimal Price,
    string PictureUrl);