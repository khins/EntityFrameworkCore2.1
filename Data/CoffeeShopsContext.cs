using Microsoft.EntityFrameworkCore;
using System;

public class CoffeeShopContext : DbContext
{
    public DbSet<Location> Locations { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<BrewerType> BrewerTypes { get; set; }

    public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options) { }
    public CoffeeShopContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CoffeeShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var location = new
        {
            LocationId = 1,
            StreetAddress = "999 Main Street",
            OpenTime = "6AM",
            CloseTime = "4PM"
        };
        modelBuilder.Entity<Location>().HasData(location);

        modelBuilder.Entity<BrewerType>().HasData(
            new BrewerType { BrewerTypeId = 1, Description = "Glass Hourglass Drip" },
            new BrewerType { BrewerTypeId = 2, Description = "Hand Press" },
            new BrewerType { BrewerTypeId = 3, Description = "Cold Brew" }
            );
        modelBuilder.Entity<Unit>().HasData(
            new Unit { UnitId = 1, Acquired = new DateTime(2018, 6, 1), BrewerTypeId = 2 },
            new Unit { UnitId = 2, Acquired = new DateTime(2018, 06, 2), BrewerTypeId = 1 }
            );

        modelBuilder.Entity<BrewerType>().OwnsOne(b => b.Recipe);
        modelBuilder.Entity<BrewerType>().OwnsOne(b => b.Recipe).HasData(
            new
            {
                BrewerTypeId = 1,
                BrewMinutes = 3,
                GrindSize = 2,
                GrindOunces = 2,
                WaterOunces = 9,
                WaterTemperatureF = 130,
                Description = "So good!"
            });
        modelBuilder.Entity<BrewerType>().OwnsOne(b => b.Recipe).HasData(
           new
           {
               BrewerTypeId = 2,
               BrewMinutes = 1,
               GrindSize = 2,
               GrindOunces = 2,
               WaterOunces = 9,
               WaterTemperatureF = 130,
               Description = "Love a hand pressed coffee!"
           });
        modelBuilder.Entity<BrewerType>().OwnsOne(b => b.Recipe).HasData(
           new
           {
               BrewerTypeId = 3,
               BrewMinutes = 60,
               GrindSize = 2,
               GrindOunces = 2,
               WaterOunces = 9,
               WaterTemperatureF = 130,
               Description = "Cold brew is worth the wait!"
           });
    }
}

