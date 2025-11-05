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
    public class PaymentConf : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
          builder.Property(p => p.Id)
                .HasConversion(p => p.ToString(), p => Ulid.Parse(p))
                .HasMaxLength(26);
            builder.Property(p => p.PaymentDate)
                .HasColumnType("DateTime");
            builder.Property(p => p.PaymentMethod)
                .HasMaxLength(10);
            builder.Property(p => p.Amount)
                .HasColumnType("decimal");
            builder.Property(p => p.Status)
                .HasMaxLength(50);
            builder.Property(p => p.ReservationID)
                .HasConversion(p => p.ToString(), p => Ulid.Parse(p))
                .HasMaxLength(26);
            builder.HasOne(p => p.Reservation).WithOne(p => p.Payment);

        }
    }
}
