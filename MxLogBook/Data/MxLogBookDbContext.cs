using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class MxLogBookDbContext : DbContext
    {
        //Setup DbContext - Inherits from base options
        public MxLogBookDbContext(DbContextOptions options) : base(options) 
        { 
        
        }

        //Create a DB Set
        public DbSet<LogItem> log_items { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        //Seed Temp Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Temp Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    Make = "Ford",
                    Model = "F-150",
                    Year = 2018,
                    Mileage = 61000,
                    CreatedOn = DateTime.UtcNow,
                },
                new Vehicle
                {
                    Id = 2,
                    Make = "Honda",
                    Model = "CRF250R",
                    Year = 2023,
                    Hours = 20,
                    CreatedOn = DateTime.UtcNow
                }
            );

            //Temp Logs
            modelBuilder.Entity<LogItem>().HasData(
                new LogItem
                {
                    Id = 1,
                    Discrepency = "Rear right hand tire has slow leak.",
                    Closed = false,
                    CreatedOn = DateTime.UtcNow,
                    VehicleId = 1
                }
            );
        }
    }
}
