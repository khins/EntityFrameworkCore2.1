using Microsoft.EntityFrameworkCore;

public class CoffeeShopContext : DbContext
{
    public DbSet<Location> Locations { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CoffeeShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasData(
            new Location
            {
                LocationId = 999,
                StreetAddress = "999 Main Street",
                OpenTime = "6AM",
                CloseTime = "4PM"
            }
        );
    }
}