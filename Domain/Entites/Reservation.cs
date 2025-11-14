namespace Domain.Entites;

public class Reservation: CommonClass.CommonBase
{
    
    public Ulid GuestID { get; set; }
    public Ulid HotelID { get; set; }
    public Ulid RoomID { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }

    public User Guest { get; set; }
    public Hotel Hotel { get; set; }
    public string Status { get; set; } = string.Empty;
    public Room Room{ get; set; } = new Room();
    public Payment Payment { get; set; } = new Payment();
}

