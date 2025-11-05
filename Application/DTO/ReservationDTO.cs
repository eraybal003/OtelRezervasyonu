using Domain.Entites;

namespace Application.DTO;
public record ReservationDTO(Ulid id,Ulid hotelid,DateTime checkin, DateTime checkout, 
    decimal price,User guest,Hotel hotel, string status, Room Room, Payment Payment);
public record ReservationCreateDTO(DateTime checkin, DateTime checkout,Hotel hotel, Room Room);
public record ReservationUpdateDTO(DateTime checkin, DateTime checkout,Hotel hotel, Room Room, string status,
    decimal price);
public record ReservationDeleteDTO(Ulid id);