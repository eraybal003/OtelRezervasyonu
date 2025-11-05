using Application.DTO;
using Domain.Entites;
using Persistence.IRepository;
using Persistence.Repository;

namespace Application.Feature;

public class ReservationService(IReservation reservation)
{
    public IEnumerable<ReservationDTO> GetReservation()
    {
        List<ReservationDTO> reservations = [];
        foreach (Reservation item in reservation.GetAll())
        {
            reservations.Add(new(item.Id,item.HotelID,item.StartDate,item.EndDate,item.TotalPrice, item.Guest,
                item.Hotel,item.Status,item.Room,item.Payment));
        }
        return reservations;

    }
    public ReservationDTO GetById(Ulid id)
    {
        var reser = reservation.FindOne(r => r.Id == id);
        if (reser == null)
        {
            return new(default, default, default, default, default, default, 
                default, string.Empty, default, default);
        }
        return new(reser.Id,reser.HotelID,reser.StartDate,reser.EndDate,reser.TotalPrice,reser.Guest,
            reser.Hotel,reser.Status,reser.Room,reser.Payment);
    }
    public ReservationDTO GetByHotel(Hotel hotel)
    {
        var reser = reservation.FindOne(r => r.Hotel == hotel);
        if (reser == null)
        {
            return new(default, default, default, default, default, default, 
                default, string.Empty, default, default);
        }
        return new(reser.Id,reser.HotelID,reser.StartDate,reser.EndDate,reser.TotalPrice,reser.Guest,
            reser.Hotel,reser.Status,reser.Room,reser.Payment);
    }
    public ReservationDTO GetByGuest(User guest)
    {
        var reser = reservation.FindOne(r => r.Guest == guest);
        if (reser == null)
        {
            return new(default, default, default, default, default, default, 
                default, string.Empty, default, default);
        }
        return new(reser.Id,reser.HotelID,reser.StartDate,reser.EndDate,reser.TotalPrice,reser.Guest,
            reser.Hotel,reser.Status,reser.Room,reser.Payment);
    }
    public ReservationDTO GetByStatus(string status)
    {
        var reser = reservation.FindOne(r => r.Status == status);
        if (reser == null)
        {
            return new(default, default, default, default, default, default, 
                default, string.Empty, default, default);
        }
        return new(reser.Id,reser.HotelID,reser.StartDate,reser.EndDate,reser.TotalPrice,reser.Guest,
            reser.Hotel,reser.Status,reser.Room,reser.Payment);
    }
    public ReservationDTO GetByRoom(Room room)
    {
        var reser = reservation.FindOne(r => r.Room == room);
        if (reser == null)
        {
            return new(default, default, default, default, default, default, 
                default, string.Empty, default, default);
        }
        return new(reser.Id,reser.HotelID,reser.StartDate,reser.EndDate,reser.TotalPrice,reser.Guest,
            reser.Hotel,reser.Status,reser.Room,reser.Payment);
    }
    public void Add(ReservationCreateDTO reservationCreate)
    {
        reservation.Add(new()
        {
            StartDate = reservationCreate.checkin,
            EndDate = reservationCreate.checkout,
            Room = reservationCreate.Room,
            Hotel = reservationCreate.hotel
        });
    }
    public void Update(ReservationUpdateDTO reservationUpdate)
    {
        reservation.Update(new()
        {
            StartDate = reservationUpdate.checkin,
            EndDate = reservationUpdate.checkout,
            Room = reservationUpdate.Room,
            Hotel = reservationUpdate.hotel,
            TotalPrice = reservationUpdate.price,
            Status = reservationUpdate.status
        });
    }
    public void Delete(ReservationDeleteDTO reservationDelete)
    {
        reservation.Delete(new()
        {
            Id = reservationDelete.id
        });
    }
}
