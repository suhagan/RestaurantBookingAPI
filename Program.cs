using Microsoft.EntityFrameworkCore;
using RestaurantBookingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This section registers all the services required for the application, including controllers, API documentation, and database context
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context service. 
// Registers the database context (RestaurantDbContext) with the dependency injection system and configures it to use SQL Server.
// The connection string is fetched from the appsettings.json configuration file using the key "DefaultConnection".
builder.Services.AddDbContext<RestaurantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
// This section adds middleware to the request pipeline for handling HTTP requests/responses
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
