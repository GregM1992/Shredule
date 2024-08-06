using Microsoft.EntityFrameworkCore;
using shredule.Models;
using Shredule.Models;
using System.Runtime.CompilerServices;

public class ShreduleDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Practice> Practices { get; set; }

    public ShreduleDbContext(DbContextOptions<ShreduleDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User { Id = 1, Name = "Greg Markus", UserName = "BassBoi92", Password = "PrimusSucks", AvailabilityId = 1 },
            new User { Id = 2, Name = "Elias Macdonald", UserName = "BigThickie", Password = "ThickieBig", AvailabilityId = 2 },
            new User { Id = 3, Name = "Justin Welch", UserName = "JasonWalkerBRI", Password = "DerfoBlood", AvailabilityId = 3 },
        });

    }
}
