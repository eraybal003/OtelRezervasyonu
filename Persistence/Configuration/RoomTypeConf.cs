using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class RoomTypeConf : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        {
            builder.Property(r => r.RoomId)
                .HasConversion(r => r.ToString(), r => Ulid.Parse(r))
                .HasMaxLength(26);
            builder.Property(r => r.Name)
                .HasMaxLength(50);
            builder.HasMany(r => r.Rooms).WithOne(r => r.RoomType);
        }
    }
}
