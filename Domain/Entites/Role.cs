using Microsoft.AspNetCore.Identity;

namespace Domain.Entites;

public class Role:IdentityRole
{
    public DateTime CreatedTime { get; set; } = DateTime.Now;

    public static string Administrator => "Administrator";
    public static string Owner => "Owner";
    public static string Customer => "Customer";


}
