using Application.DTO;
using Domain.Entites;
using Persistence.IRepository;

namespace Application.Feature;

public class RoomTypeService(IRoomType roomType)
{
    public IEnumerable<RoomTypeDTO> GetTypes()
    {
        List<RoomTypeDTO> roomTypes = [];
        foreach (RoomType item in roomType.GetAll())
        {
            roomTypes.Add(new(item.Id,item.Name,item.Description,item.RoomId,item.Rooms));
        }
        return roomTypes;
    }
    public RoomTypeDTO GetById(Ulid id)
    {
        var type = roomType.FindOne(x => x.Id == id);
        if (type == null)
        {
            return new(default,string.Empty,string.Empty,default,default);
        }
        return new(type.Id, type.Name, type.Description, type.RoomId, type.Rooms);
    }
    public RoomTypeDTO GetByName(string name)
    {
        var type = roomType.FindOne(x => x.Name == name);
        if (type == null)
        {
            return new(default,string.Empty,string.Empty,default,default);
        }
        return new(type.Id, type.Name, type.Description, type.RoomId, type.Rooms);
    }
    public void Add(RoomTypeCreateDTO typeCreate)
    {
        roomType.Add(new()
        {
            Name = typeCreate.name,
            Description = typeCreate.description,
        });
    }
    public void Update(RoomTypeUpdateDTO typeUpdate)
    {
        roomType.Update(new()
        {
            Name = typeUpdate.name,
            Description = typeUpdate.description
        });
    }
    public void Delete(RoomTypeDeleteDTO typeDelete)
    {
        roomType.Delete(new()
        {
            Id = typeDelete.id
        });
    }
}
