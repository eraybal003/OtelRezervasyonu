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
    public class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           /* builder.Property(u => u.Id)
                .HasMaxLength(26);
            builder.HasMany(u => u.Reservations).WithOne(u => u.Guest);*/
        }
    }
}
