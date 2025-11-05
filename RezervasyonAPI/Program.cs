using Application;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DBConn");
Console.WriteLine($"🔗 Program.cs - Connection String: {connString}");
// Add services to the container.

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAppServices();
builder.Services.AddControllers();
builder.Services.AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<DbContext>()
    .AddDefaultTokenProviders();
var serviceProvider = builder.Services.BuildServiceProvider();
try
{
    var context = serviceProvider.GetRequiredService<AppDBContext>();
    Console.WriteLine("✅ DbContext registered successfully in DI");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ DbContext registration failed: {ex.Message}");
}
builder.Services.AddOpenApi();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 16;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;    

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using(var servicescope = app.Services.CreateScope())
{
    var services = servicescope.ServiceProvider;
    var dbcontext = services.GetRequiredService<DbContext>();
    dbcontext.Database.EnsureCreated();

    var rolmanager = services.GetRequiredService<RoleManager<Role>>();
    if (!await rolmanager.RoleExistsAsync(Role.Administrator))
    {
        await rolmanager.CreateAsync(new Role()
        {
            Id = Ulid.NewUlid().ToString(),
            Name = Role.Administrator,
            CreatedTime = DateTime.Now

        });
    }
    if (!await rolmanager.RoleExistsAsync(Role.Owner))
    {
        await rolmanager.CreateAsync(new Role()
        {
            Id = Ulid.NewUlid().ToString(),
            Name = Role.Owner,
            CreatedTime = DateTime.Now

        });
    }
    if (!await rolmanager.RoleExistsAsync(Role.Customer))
    {
        await rolmanager.CreateAsync(new Role()
        {
            Id = Ulid.NewUlid().ToString(),
            Name = Role.Customer,
            CreatedTime = DateTime.Now

        });
    }

}

app.MapControllers();

app.Run();
