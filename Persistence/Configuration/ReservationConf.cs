using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ReservationConf : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.Id)
                .HasConversion(r => r.ToString(), r => Ulid.Parse(r));
            builder.Property(rn => rn.StartDate)
                .HasColumnType("DateTime");
            builder.Property(rn => rn.EndDate)
                .HasColumnType("DateTime");
            builder.Property(rn => rn.TotalPrice)
                .HasColumnType("decimal");
            builder.Property(rn => rn.Status)
                .HasMaxLength(50);
            builder.Property(r => r.GuestID)
                .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
                .HasMaxLength(26);
            builder.Property(r => r.HotelID)
                .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
                .HasMaxLength(26);
            builder.Property(r => r.RoomID)
                .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
                .HasMaxLength(26);
            builder.HasOne(rn => rn.Guest).WithMany(rn => rn.Reservations);
            builder.HasOne(rn => rn.Payment).WithOne(rn => rn.Reservation);
            builder.HasOne(rn => rn.Room).WithMany(rn => rn.Reservations);
            builder.HasOne(rn => rn.Hotel).WithMany(rn => rn.Reservations);

        }
    }
}
