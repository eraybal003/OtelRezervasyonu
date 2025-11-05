using Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Context;

public class AppDBContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<RoomType> RoomType { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Reservation> Booking { get; set; }
    public DbSet<Hotel> Hotel  { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        base.OnModelCreating(builder);
    }
}

