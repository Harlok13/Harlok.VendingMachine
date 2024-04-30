using Harlok.VendingMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harlok.VendingMachine.Infrastructure.DAL.Context;

public class VendingMachineContext : DbContext
{
    public VendingMachineContext(DbContextOptions<VendingMachineContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);
    }

    public DbSet<Drink> Drinks { get; init; } = null!;
    public DbSet<Domain.Entities.VendingMachine> VendingMachines { get; init; } = null!;
    public DbSet<User> Users { get; init; } = null!;

}