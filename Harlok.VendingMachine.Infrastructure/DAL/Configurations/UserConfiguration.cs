using Harlok.VendingMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Harlok.VendingMachine.Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id).HasName("user_pkey");
        
        builder.ToTable("user");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("UUID");

        builder.Property(e => e.Coins)
            .HasColumnName("coins")
            .HasColumnType("jsonb");

        builder.HasData(User.Create(Guid.NewGuid(), new()));
    }
}