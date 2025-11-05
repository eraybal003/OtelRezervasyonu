using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class RoomConf : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
       builder.Property(r => r.Id)
            .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
            .HasMaxLength(26);
        builder.Property(r => r.RoomNumber)
            .HasColumnType("int")
            .HasMaxLength(700);
        builder.Property(r => r.Price)
            .HasColumnType("decimal");
        builder.Property(r => r.IsAvailable)
            .HasColumnType("bool");
        builder.Property(r => r.RoomTypeId)
            .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
            .HasMaxLength(26);
        builder.Property(r => r.HotelId)
            .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
            .HasMaxLength(26);
        builder.Property(r => r.ReservationId)
            .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
            .HasMaxLength(26);
        builder.HasOne(r => r.RoomType).WithMany(r => r.Rooms).HasForeignKey(r => r.RoomTypeId);
        builder.HasMany(r => r.Reservations).WithOne(r => r.Room).HasForeignKey(r => r.RoomID);
        builder.HasOne(r => r.Hotel).WithMany(r => r.Rooms).HasForeignKey(r => r.HotelId);

    }
}
