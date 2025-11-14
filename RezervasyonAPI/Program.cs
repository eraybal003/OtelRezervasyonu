using Application;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;
using RezervasyonAPI;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DBConn");
Console.WriteLine($"🔗 Program.cs - Connection String: {connString}");
// Add services to the container.

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAppServices();
builder.Services.AddControllers();
builder.Services.AddIdentity<User, Role>(opt =>
{
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 16;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddDataProtection();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

await Seeder.SeedData(app);
app.Run();
