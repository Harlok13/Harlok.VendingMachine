using Harlok.VendingMachine.Domain.Enums;

namespace Harlok.VendingMachine.Domain.Primitives;

public record Coin(
    Guid Id,
    ECoinDenomination Denomination);