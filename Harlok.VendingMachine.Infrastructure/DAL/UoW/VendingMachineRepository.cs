using Harlok.Core.Exceptions;
using Harlok.VendingMachine.Application.Repositories;
using Microsoft.EntityFrameworkCore;

using static Harlok.VendingMachine.Infrastructure.Messages.MessageConstants;

namespace Harlok.VendingMachine.Infrastructure.DAL.UoW;

public class VendingMachineRepository<TContext> : IVendingMachineRepository
    where TContext : DbContext
{
    private readonly TContext _context;

    public VendingMachineRepository(TContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Domain.Entities.VendingMachine> GetVendingMachineAsync(long id, CancellationToken cT)
    {
        var vendingMachine = await _context.Set<Domain.Entities.VendingMachine>()
            .Where(vm => vm.Id == id)
            .Include(vm => vm.Drinks)
            .SingleOrDefaultAsync(cT);

        if (vendingMachine is null)
            throw new VendingMachineNotFoundException(string.Format(VendingMachineNotFound, id));

        return vendingMachine;
    }
}