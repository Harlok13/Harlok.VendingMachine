using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Contracts.Request;

public sealed record AddCoinsRequest(
    IReadOnlyCollection<Coin> Coins);