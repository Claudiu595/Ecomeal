using ecomea.api.Entities;
using EcoMeal.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.API.Infrastructure;
public class EcoMealDbContext : DbContext
{
    public EcoMealDbContext(DbContextOptions<EcoMealDbContext> options)
     : base(options)
    {}
    public DbSet<User> Users {get;set;}
    public DbSet<BusinessType> BusinessType {get;set;}
    public DbSet<PackageType> PackageType {get;set;}
    public DbSet<Business> Business{get;set;}
    public DbSet<Order> Order{get;set;}
    public DbSet<Package> Package{get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Business>().HasKey(e => e.ID);
        modelBuilder.Entity<Business>()
            .HasOne(p => p.BusinessType)
            .WithMany(p => p.Businesses)
            .HasForeignKey(p => p.BusinessTypeID);

        modelBuilder.Entity<PackageType>().HasData(
            new PackageType { ID = 1, Name = "Standard" },
            new PackageType { ID = 2, Name = "Vegetarian" },
            new PackageType { ID = 3, Name = "Premium" }
        );
    }
}
