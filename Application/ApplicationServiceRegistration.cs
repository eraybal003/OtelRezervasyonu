using Application.Feature;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection descriptors)
    {
        descriptors.AddScoped<HotelService, HotelService>();
        descriptors.AddScoped<RoomService, RoomService>();
        descriptors.AddScoped<RoomTypeService, RoomTypeService>();
        descriptors.AddScoped<ReservationService, ReservationService>();
        descriptors.AddScoped<PaymentServ, PaymentServ>();

        return descriptors;
    }
}
