using Microsoft.EntityFrameworkCore;

public class CoffeeShopContext : DbContext
{
    public DbSet<Location> Locations { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CoffeeShops.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasData(
            new Location
		    {
			    LocationId = 1,
			    StreetAddress="1 Main Street",
			    OpenTime = "6AM",
			    CloseTime = "4PM"
		    }
        );
    }
}