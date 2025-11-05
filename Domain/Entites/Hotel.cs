namespace Domain.Entites;

public class Hotel: CommonClass.CommonBase
{  
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Stars { get; set; }
    public DateTime CheckInTime { get; set; } = DateTime.Now;
    public DateTime? CheckOutTime { get; set; }


    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

}
