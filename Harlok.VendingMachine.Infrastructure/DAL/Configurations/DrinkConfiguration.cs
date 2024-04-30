using Harlok.VendingMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Harlok.VendingMachine.Infrastructure.DAL.Configurations;

public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.HasKey(e => e.Id).HasName("drink_pkey");

        builder.ToTable("drink");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("bigint");

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Price)
            .HasColumnName("price")
            .HasColumnType("numeric(7, 2)")
            .IsRequired();

        builder.Property(e => e.PictureUrl)
            .HasColumnName("picture_url")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(e => e.VendingMachineId)
            .HasColumnName("vending_machine_id")
            .HasColumnType("bigint");

        builder.HasOne(e => e.VendingMachine)
            .WithMany()
            .HasForeignKey("vending_machine_fk");

        // builder.HasData(new List<Drink>()
        // {
        //     Drink.Create(1, "Juice", 54, "img/drinks/juice.jpg", 23, 13),
        //     Drink.Create(1, "Cola", 73, "img/drinks/cola.jpg", 31, 13)
        // });
    }
}