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
            new User { Id = 1, Name = "Greg Markus", UserName = "BassBoi92", Password = "PrimusSucks", AvailabilityId = 1, ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthenounproject.com%2Fbrowse%2Ficons%2Fterm%2Fblank-profile%2F&psig=AOvVaw1htfEIJYHXkNrLoKRBHDLk&ust=1731620342893000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCB1c2i2okDFQAAAAAdAAAAABAE" },
            new User { Id = 2, Name = "Elias Macdonald", UserName = "BigThickie", Password = "ThickieBig", AvailabilityId = 2, ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthenounproject.com%2Fbrowse%2Ficons%2Fterm%2Fblank-profile%2F&psig=AOvVaw1htfEIJYHXkNrLoKRBHDLk&ust=1731620342893000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCB1c2i2okDFQAAAAAdAAAAABAE" },
            new User { Id = 3, Name = "Justin Welch", UserName = "JasonWalkerBRI", Password = "DerfoBlood", AvailabilityId = 3, ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthenounproject.com%2Fbrowse%2Ficons%2Fterm%2Fblank-profile%2F&psig=AOvVaw1htfEIJYHXkNrLoKRBHDLk&ust=1731620342893000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCB1c2i2okDFQAAAAAdAAAAABAE" },
        });

        modelBuilder.Entity<Band>().HasData(new Band[] {
            new Band { Id = 1, LeaderId = 1, Name = "Cull", Password ="nunusCrawfish", ScheduleId = 1, ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.istockphoto.com%2Fphotos%2Flive-crawfish&psig=AOvVaw2JjsOS4Pa4iECZ35pGTyiL&ust=1731620204747000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPDz_Yui2okDFQAAAAAdAAAAABAE" },
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
