using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace RezervasyonAPI;

public class Seeder
{
    public static async Task SeedData(IApplicationBuilder builder1)
    {
        using var scope = builder1.ApplicationServices.CreateScope();
        try
        {
            var usermanager = scope.ServiceProvider.GetService<UserManager<User>>();
            var rolemanager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            if (usermanager.Users.Any() == false)
            {
                var user = new User
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    UserName = "superAdmin",
                    Email = "superadmin@hotmail.com",
                    EmailConfirmed = true,
                    SecurityStamp = Ulid.NewUlid().ToString()

                };
                if (await rolemanager.RoleExistsAsync(Role.Administrator) == false)
                {
                    Console.WriteLine("Admin role is creating");
                    var roleresult = await rolemanager.CreateAsync(new IdentityRole(Role.Administrator));
                    if (!roleresult.Succeeded)
                    {
                        var roleerror = roleresult.Errors.Select(x => x.Description);
                        Console.WriteLine($"Failed to create admin role. Error: {string.Join(",", roleerror)}");
                        return;
                    }
                    Console.WriteLine("Admin role is created");
                }
                Console.WriteLine("User is creating...");
                var userresult = await usermanager.CreateAsync(user, "Admin@123");
                if (!userresult.Succeeded)
                {
                    var usererror = userresult.Errors.Select(x => x.Description);
                    Console.WriteLine($"Failed to create admin role to user. Error: {string.Join(",", usererror)}");
                    return;
                }
                Console.WriteLine("User was created Succesfully");

                var userroleresult = await usermanager.AddToRoleAsync(user, Role.Administrator);

                if (!userroleresult.Succeeded)
                {
                    var roleerror = userroleresult.Errors.Select(x => x.Description);
                    Console.WriteLine($"Failed to create admin role to user. Error: {string.Join(",", roleerror)}");
                    return;
                }
                Console.WriteLine("Admin user was created Successfully");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
}

