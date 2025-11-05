using Domain.Entites;

namespace Application.DTO;

public record HotelDTO(Ulid id, string name, string address,string phone,string email, int stars,  
    DateTime checkin,DateTime? checkout, ICollection<Room> Rooms, ICollection<Reservation> Reservations);
public record HotelCreateDTO(string name, string address,string phone,string email, int stars, ICollection<Room> Rooms);
public record HotelUpdateDTO(string name, string address,string phone,string email);
public record HotelDeleteDTO(Ulid id);


