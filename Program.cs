using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration["ConnectionStrings:defaultConnection"];

builder.Services
    .AddDbContext<ApiDbContext>(options => options.UseSqlite(conn));

// builder.Services.AddControllers();

var app = builder.Build();

//
// app.UseHttpsRedirection();
//
// app.UseAuthorization();
//
// app.MapControllers();

app.MapGet("/hello", () =>
{
    return "Hello from dotnet";
});

app.MapPost("/hello", (string name) =>
{
    return $"Hello {name}";
});

app.MapPost("/users", async (ApiDbContext db, User user) =>
{
    try
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();
        return Results.Ok();
    }
    catch (Exception e)
    {
        return Results.BadRequest(e.Message);
    }
});

app.Run();


class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

class ApiDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
        
    }
}