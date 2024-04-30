using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Contracts.Request;

public sealed record DepositCoinRequest(
    long VendingMachineId,
    Coin Coin);