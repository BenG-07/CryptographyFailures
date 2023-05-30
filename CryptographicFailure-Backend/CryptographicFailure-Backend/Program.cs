using CryptographicFailure_Backend;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Build configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

// Register database context
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySQL(connectionString));

var app = builder.Build();

// Configure endpoints
app.MapPost("/api/register", async (User user, DatabaseContext context) =>
{
    user.Id = context.Users.Max(x => x.Id) + 1;
    await context.Users.AddAsync(user);
    await context.SaveChangesAsync();
    return Results.Created($"/new/{user.Id}", user);
});
app.MapPost("/api/login", async (User user, DatabaseContext context) =>
{
    var x = await context.Users.FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
    return x == null ? Results.BadRequest() : Results.Ok();
});

app.Run();
