using Harlok.Core.Exceptions;
using Harlok.VendingMachine.Domain.Entities;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Application.Repositories;

public interface IUserRepository
{
    /// <summary>
    ///     Get user.
    /// </summary>
    /// <param name="cT">cancellation token.</param>
    /// <returns>a <see cref="User"/> entity.</returns>
    /// <exception cref="UserNotFoundException">user not found.</exception>
    Task<User> GetUserAsync(CancellationToken cT);

    /// <summary>
    ///     Get user coins.
    /// </summary>
    /// <param name="cT">cancellation token.</param>
    /// <returns>collection of coins that the user has.</returns>
    /// <exception cref="UserNotFoundException">user not found.</exception>
    Task<IReadOnlyCollection<Coin>> GetCoinsAsNoTrackingAsync(CancellationToken cT);
}