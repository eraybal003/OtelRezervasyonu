using Application.DTO;
using Domain.Entites;
using Persistence.IRepository;
namespace Application.Feature;

public class HotelService(IHotel hotel)
{
    public IEnumerable<HotelDTO> GetHotels()
    {
        List<HotelDTO> hotels = [];
        foreach (Hotel item in hotel.GetAll())
        {
            hotels.Add(new(item.Id, item.Name,item.Address,item.Phone,
                item.Email,item.Stars,item.CheckInTime,item.CheckOutTime,item.Rooms,item.Reservations));
        }
        return hotels;
    }
    public HotelDTO GetById(Ulid id)
    {
        var _hotel = hotel.FindOne(_hotel => _hotel.Id == id);
        if (_hotel == null)
        {
            return new(default, string.Empty, string.Empty, string.Empty, string.Empty,
                default, default, default, default, default);
        }
        return new(_hotel.Id,_hotel.Name,_hotel.Address,_hotel.Phone,_hotel.Email,
            _hotel.Stars,_hotel.CheckInTime,_hotel.CheckOutTime,_hotel.Rooms,_hotel.Reservations);
    }
    public HotelDTO GetByName(string name)
    {
        var _hotel = hotel.FindOne(_hotel => _hotel.Name == name);
        if (_hotel == null)
        {
            return new(default, string.Empty, string.Empty, string.Empty, string.Empty,
                default, default, default, default, default);
        }
        return new(_hotel.Id,_hotel.Name,_hotel.Address,_hotel.Phone,_hotel.Email,
            _hotel.Stars,_hotel.CheckInTime,_hotel.CheckOutTime,_hotel.Rooms,_hotel.Reservations);
    }
    public HotelDTO GetByStar(int star)
    {
        var _hotel = hotel.FindOne(_hotel => _hotel.Stars == star);
        if (_hotel == null)
        {
            return new(default, string.Empty, string.Empty, string.Empty, string.Empty,
                default, default, default, default, default);
        }
        return new(_hotel.Id,_hotel.Name,_hotel.Address,_hotel.Phone,_hotel.Email,
            _hotel.Stars,_hotel.CheckInTime,_hotel.CheckOutTime,_hotel.Rooms,_hotel.Reservations);
    }
    public void Add(HotelCreateDTO hotelCreate)
    {
        hotel.Add(new()
        {
            Name = hotelCreate.name,
            Address = hotelCreate.address,
            Phone = hotelCreate.phone,
            Email = hotelCreate.email,
            Rooms = hotelCreate.Rooms
        });
    }
    public void Update(HotelUpdateDTO hotelUpdate)
    {
        hotel.Update(new()
        {
            Name = hotelUpdate.name,
            Address = hotelUpdate.address,
            Phone = hotelUpdate.phone,
            Email = hotelUpdate.email
        });
    }
    public void Delete(HotelDeleteDTO hotelDelete)
    {
        hotel.Delete(new()
        {
            Id = hotelDelete.id
        });
    }
}
