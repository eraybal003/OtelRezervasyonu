using Domain.Entites;

namespace Application.DTO;

public record RoomTypeDTO(Ulid id, string name, string description,Ulid roomid ,ICollection<Room> Rooms);
public record RoomTypeCreateDTO( string name, string description);
public record RoomTypeUpdateDTO( string name, string description);
public record RoomTypeDeleteDTO(Ulid id);