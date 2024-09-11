using Microsoft.EntityFrameworkCore;
using Shredule.Models;
using System.Runtime.CompilerServices;

public class ShreduleDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Practice> Practices { get; set; }
    public DbSet<Availability> Availability { get; set; }

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

        modelBuilder.Entity<Band>().HasData(new Band[] {
            new Band { Id = 1, Name = "Cull", Password ="nunusCrawfish", ScheduleId = 1, LeaderId = 1},
        });

        modelBuilder.Entity<Show>().HasData(new Show[] {
            new Show { Id = 2, DateTime = new DateTime(24,09,04), Venue ="BlackBird Tattoo", BandId = 1 },

        });
        modelBuilder.Entity<Practice>().HasData(new Practice[] {
            new Practice { Id = 1, BandId = 1, DateTime= new DateTime(24,09,02) },
        });
        modelBuilder.Entity<Availability>().HasData(new Availability[] {
            new Availability { Id = 1, UserId = 1, MonMorn = true, TueMorn = true, WedMorn = false, ThurMorn = false, FriMorn = false, SatMorn = true, SunMorn = false, MonNight = true, TueNight = false, WedNight = true, ThurNight = true, FriNight = false, SatNight = true, SunNight = false },
            new Availability { Id = 2, UserId = 2, MonMorn = false,TueMorn = true, WedMorn = true, ThurMorn = false, FriMorn = false, SatMorn = true, SunMorn = false, MonNight = true, TueNight = false, WedNight = true, ThurNight = false, FriNight = false, SatNight = true, SunNight = true }, 
        });
    }
}
