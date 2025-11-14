using Application.Feature;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection descriptors)
    {
        descriptors.AddScoped<HotelService>();
        descriptors.AddScoped<RoomService>();
        descriptors.AddScoped<RoomTypeService>();
        descriptors.AddScoped<ReservationService>();
        descriptors.AddScoped<PaymentServ>();

        return descriptors;
    }
}
