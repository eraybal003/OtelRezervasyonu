using Microsoft.AspNetCore.Identity;

namespace Domain.Entites;

public class User:IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
