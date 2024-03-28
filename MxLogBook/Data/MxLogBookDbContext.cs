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
        public DbSet<CompanyUserRoles> CompanyUserRoles { get; set; }
        public DbSet<Roles> CompanyRoles { get; set; }

        //Seed Temp Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyUserRoles>()
                .HasKey(c => new { c.UserId, c.CompanyId, c.RoleId });

            modelBuilder.Entity<CompanyUserRoles>()
                .HasOne(c => c.ApplicationUser)
                .WithMany(u => u.CompanyUserRoles)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CompanyUserRoles>()
                .HasOne(c => c.Company)
                .WithMany(u => u.CompanyUserRoles)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<CompanyUserRoles>()
                .HasOne(c => c.Role)
                .WithMany(u => u.CompanyUserRoles)
                .HasForeignKey(c => c.RoleId);

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
                }
            );
        }
    }
}
