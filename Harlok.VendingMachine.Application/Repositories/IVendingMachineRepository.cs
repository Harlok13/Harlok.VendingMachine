using Harlok.Core.Exceptions;

namespace Harlok.VendingMachine.Application.Repositories;

public interface IVendingMachineRepository
{
    /// <summary>
    ///     Get a vending machine by ID.
    /// </summary>
    /// <param name="id">vending machine id.</param>
    /// <param name="cT">cancellation token.</param>
    /// <returns>A <see cref="Domain.Entities.VendingMachine"/> entity.</returns>
    /// <exception cref="VendingMachineNotFoundException">vending machine was not found.</exception>
    Task<Domain.Entities.VendingMachine> GetVendingMachineAsync(long id, CancellationToken cT);
}