using Microsoft.EntityFrameworkCore;
using TastyPoint.API.Shared.Persistence.Extensions;
using TastyPoint.API.TastyPoint.Domain.Models;

namespace TastyPoint.API.Shared.Persistence.Contexts;

public class TastyPointDbContext : DbContext
{
    protected TastyPointDbContext()
    {
    }

    public TastyPointDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Food?> Foods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Categories
        modelBuilder.Entity<Food>().ToTable("Food");
        modelBuilder.Entity<Food>().HasKey(p => p.FoodId);
        modelBuilder.Entity<Food>().Property(p => p.FoodId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Food>().Property(p => p.FoodName).IsRequired();
        modelBuilder.Entity<Food>().Property(p => p.PhotoUrl).IsRequired();
        
        
        modelBuilder.SnakeCaseNamingConvention();
    }
}