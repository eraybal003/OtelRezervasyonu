 namespace Domain.Entites;

public class Payment: CommonClass.CommonBase
{
    public  Ulid ReservationID { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public string PaymentMethod { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public Reservation Reservation { get; set; } = null!;
}