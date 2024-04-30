using Harlok.Core.Exceptions;
using Harlok.VendingMachine.Application.Repositories;
using Harlok.VendingMachine.Domain.Entities;
using Harlok.VendingMachine.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

using static Harlok.VendingMachine.Infrastructure.Messages.MessageConstants;

namespace Harlok.VendingMachine.Infrastructure.DAL.UoW;

public class UserRepository<TContext> : IUserRepository
    where TContext : DbContext
{
    private readonly TContext _context;

    public UserRepository(TContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserAsync(CancellationToken cT)
    {
        User? user = await _context.Set<User>().FirstOrDefaultAsync(cT);
        if (user is null)
            throw new UserNotFoundException(UserNotFound);

        return user;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<Coin>> GetCoinsAsNoTrackingAsync(CancellationToken cT)
    {
        User? user = await _context.Set<User>()
            .AsNoTracking()
            .FirstOrDefaultAsync(cT);
        
        if (user is null)
            throw new UserNotFoundException(UserNotFound);

        return user.Coins;
    }
}