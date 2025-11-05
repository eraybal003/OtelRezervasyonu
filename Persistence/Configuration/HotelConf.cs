using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class HotelConf : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
       builder.Property(h => h.Id)
           .HasMaxLength(26)
           .HasConversion(h => h.ToString(), h => Ulid.Parse(h));
        builder.Property(h => h.Name)
            .HasMaxLength(100);
        builder.Property(h => h.Address)
            .HasMaxLength(120);
        builder.Property(h => h.Phone)
            .HasColumnType("string")
            .HasMaxLength(11);
        builder.Property(h => h.Stars)
            .HasColumnType("int")
            .HasMaxLength(5);
        builder.Property(h => h.CheckInTime)
            .HasColumnType("DateTime");
        builder.Property(h => h.CheckOutTime)
            .HasColumnType("DateTime");

        builder.HasMany(h => h.Rooms).WithOne(h => h.Hotel);
    }
}
