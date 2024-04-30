using Harlok.VendingMachine.Contracts.Data;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Contracts.Request;

public sealed record BuyDrinksRequest(
    long VendingMachineId,
    IReadOnlyCollection<BuyDrinkInfo> BuyDrinkInfos);