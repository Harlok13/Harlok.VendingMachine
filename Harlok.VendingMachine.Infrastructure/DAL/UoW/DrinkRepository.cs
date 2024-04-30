using Harlok.VendingMachine.Application.Repositories;
using Harlok.VendingMachine.Contracts.Data;
using Harlok.VendingMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harlok.VendingMachine.Infrastructure.DAL.UoW;

public class DrinkRepository<TContext> : IDrinkRepository
    where TContext : DbContext
{
    private readonly TContext _context;

    public DrinkRepository(TContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DrinkDto>> GetAllDrinksAsNoTrackingAsync(CancellationToken cT)
    {
        IEnumerable<DrinkDto> drinks = await _context.Set<Drink>()
            .Select(d => new DrinkDto(
                d.Id,
                d.Name,
                d.Price,
                d.PictureUrl))
            .ToListAsync(cT);

        return drinks;
    }
}