namespace Domain.Entites;

public class Room:CommonClass.CommonBase
{  
    public string RoomNumber { get; set; } = string.Empty;
    public Ulid RoomTypeId { get; set; } 
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Ulid HotelId { get; set; }
    public Hotel? Hotel { get; set; } 
    public RoomType? RoomType { get; set; } 
    public Ulid ReservationId { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

}
