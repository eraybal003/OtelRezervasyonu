using Microsoft.AspNetCore.Identity;

namespace Domain.Entites;

public class User:IdentityUser
{
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public ICollection<Reservation> Reservations { get; set; } = null!;
}
