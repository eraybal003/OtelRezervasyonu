using Application.DTO;
using Domain.Entites;
using Persistence.IRepository;

namespace Application.Feature;

public class RoomService(IRoom room)
{
    public IEnumerable<RoomDTO> GetRoomDTOs()
    {
        List<RoomDTO> rooms = [];
        foreach (Room item in room.GetAll())
        {
            rooms.Add(new(item.Id,item.RoomNumber,item.Price,item.IsAvailable,item.Hotel,item.RoomType,item.Reservations));
        }
        return rooms;
    }
    public RoomDTO GetById(Ulid id)
    {
        var _room = room.FindOne(_room => _room.Id == id);
        if (_room == null)
        {
            return new(default, string.Empty, default, default, default, default, default);
        }
        return new(_room.Id, _room.RoomNumber, _room.Price, _room.IsAvailable, _room.Hotel, _room.RoomType, _room.Reservations);
    }
    public RoomDTO GetByNumber(string number)
    {
        var _room = room.FindOne(_room => _room.RoomNumber == number);
        if (_room == null)
        {
            return new(default, string.Empty, default, default, default, default, default);
        }
        return new(_room.Id, _room.RoomNumber, _room.Price, _room.IsAvailable, _room.Hotel, _room.RoomType, _room.Reservations);
    }
    public RoomDTO GetByAvability(bool available)
    {
        var _room = room.FindOne(_room => _room.IsAvailable == available);
        if (_room == null)
        {
            return new(default, string.Empty, default, default, default, default, default);
        }
        return new(_room.Id, _room.RoomNumber, _room.Price, _room.IsAvailable, _room.Hotel, _room.RoomType, _room.Reservations);
    }
    public void Add(RoomCreateDTO room1)
    {
        room.Add(new()
        {
            RoomNumber = room1.roomnumber,
            RoomType = room1.roomtype,
            Price = room1.roomprice,
            IsAvailable = room1.isavailable
        });
    }
    public void Update(RoomUpdateDTO room1)
    {
        room.Add(new()
        {
            RoomNumber = room1.roomnumber,
            RoomType = room1.roomtype,
            Price = room1.roomprice,
            IsAvailable = room1.isavailable,
        });
    }
    public void Delete(RoomDeleteDTO room1)
    {
        room.Add(new()
        {
            Id = room1.id

        });
    }

}
