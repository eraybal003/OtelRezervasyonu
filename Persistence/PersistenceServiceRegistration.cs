using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.IRepository;
using Persistence.Repository;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DBConn")));

        services.AddScoped<IHotel, HotelRepo>();
        services.AddScoped<IRoom, RoomRepo>();
        services.AddScoped<IRoomType, RoomTypeRepo>();
        services.AddScoped<IReservation, ReservationRepo>();
        services.AddScoped<IPayment, PaymentRepo>();

        return services;
    }
}
