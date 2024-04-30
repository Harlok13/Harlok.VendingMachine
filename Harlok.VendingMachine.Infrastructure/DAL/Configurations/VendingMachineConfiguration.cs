using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Harlok.VendingMachine.Infrastructure.DAL.Configurations;

public class VendingMachineConfiguration : IEntityTypeConfiguration<Domain.Entities.VendingMachine>
{
    private const long DefaultVendingMachineId = 13;
    
    public void Configure(EntityTypeBuilder<Domain.Entities.VendingMachine> builder)
    {
        builder.HasKey(e => e.Id).HasName("vending_machine_pkey");

        builder.ToTable("vending_machine");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("bigint");

        builder.Property(e => e.Deposit)
            .HasColumnName("deposit")
            .HasColumnType("jsonb");

        builder.Property(e => e.EarnedMoney)
            .HasColumnName("earned_money")
            .HasColumnType("numeric(7, 2)");

        builder.HasMany(e => e.Drinks)
            .WithOne();

        builder.HasData(new List<Domain.Entities.VendingMachine>()
        {
            Domain.Entities.VendingMachine.Create(DefaultVendingMachineId)
        });
    }
}