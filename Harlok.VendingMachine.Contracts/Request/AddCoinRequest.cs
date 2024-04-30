using Harlok.VendingMachine.Domain.Enums;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Contracts.Request;

public sealed record AddCoinRequest(
    Coin Coin);