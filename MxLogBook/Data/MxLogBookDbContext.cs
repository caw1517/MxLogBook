using Backend.Models;
using Backend.Models.RelationshipTables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    //Db uses Identity Db Context
    public class MxLogBookDbContext : IdentityDbContext<ApplicationUser>
    {
        //Setup DbContext - Inherits from base options
        public MxLogBookDbContext(DbContextOptions options) : base(options) 
        { 
        
        }

        //Create a DB Set
        public DbSet<LogItem> LogItems { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<SignOff> SignOffs { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<InviteToken> Invites { get; set; }

        //Seed Temp Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasMany(x => x.ApplicationUsers)
                .WithMany(y => y.Companies)
                .UsingEntity(j => j.ToTable("CompanyUser"));

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
                    UserId = "66b55995-d23f-4b07-ab16-6425b63c603d",
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
                    VehicleId = 1,
                    UserId = "66b55995-d23f-4b07-ab16-6425b63c603d"
                }
            );

            //Seed Default Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "CompanyUser",
                    NormalizedName = "COMPANYUSER"
                },
                new IdentityRole
                {
                    Name = "CompanyAdmin",
                    NormalizedName = "COMPANYADMIN"
                }
            );
        }
    }
}
