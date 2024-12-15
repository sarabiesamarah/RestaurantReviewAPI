using Microsoft.EntityFrameworkCore;
using RestaurantReviewAPI.Models;

namespace RestaurantReviewAPI.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
