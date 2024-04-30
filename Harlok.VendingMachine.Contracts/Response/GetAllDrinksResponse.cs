using Harlok.VendingMachine.Contracts.Base;
using Harlok.VendingMachine.Contracts.Data;

namespace Harlok.VendingMachine.Contracts.Response;

public sealed record GetAllDrinksResponse(
    IEnumerable<DrinkDto> Drinks) : IApiResult;