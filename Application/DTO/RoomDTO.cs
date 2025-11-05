using Domain.Entites;

namespace Application.DTO;
public record RoomDTO(Ulid id, string roomnumber,decimal roomprice, bool isavailable, 
     Hotel hotel, RoomType roomtype, ICollection<Reservation> reservations);
public record RoomCreateDTO(string roomnumber,decimal roomprice, bool isavailable, RoomType roomtype);
public record RoomUpdateDTO(string roomnumber,decimal roomprice, bool isavailable, RoomType roomtype);
public record RoomDeleteDTO(Ulid id);

