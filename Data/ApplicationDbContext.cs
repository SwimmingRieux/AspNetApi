using FoodApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<RestaurantFood> RestaurantFoods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RestaurantFood>()
            .HasKey(rf => new { rf.RestaurantId, rf.FoodId });

        modelBuilder.Entity<RestaurantFood>()
            .HasOne(rf => rf.Restaurant)
            .WithMany(r => r.RestaurantFoods)
            .HasForeignKey(rf => rf.RestaurantId);

        modelBuilder.Entity<RestaurantFood>()
            .HasOne(rf => rf.Food)
            .WithMany(f => f.RestaurantFoods)
            .HasForeignKey(rf => rf.FoodId);
    }
}