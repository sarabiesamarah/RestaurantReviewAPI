using Microsoft.EntityFrameworkCore;
using RestaurantReviewAPI.Data;
using RestaurantReviewAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register SQLite database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=restaurant.db"));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

if (!context.Restaurants.Any())
{
    context.Restaurants.AddRange(
        new Restaurant { Name = "Test Restaurant", Location = "NYC", Cuisine = "Italian", Rating = 4.5 },
        new Restaurant { Name = "Another Restaurant", Location = "London", Cuisine = "British", Rating = 4.0 }
    );
    context.SaveChanges();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

    app.Run();
}