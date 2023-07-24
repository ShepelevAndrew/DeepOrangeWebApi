using DeepOrangeWebApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeepOrangeWebApi.DAL.EF;
public class DbContextApp : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Direction> Directions { get; set; }

    public DbContextApp(DbContextOptions<DbContextApp> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Technology>()
            .HasOne(t => t.Direction)
            .WithMany(d => d.Technologies)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Profile>()
            .HasMany(p => p.Technologies)
            .WithMany(t => t.Profiles)
            .UsingEntity(j => j.ToTable("ProfileTechnologies"));

        base.OnModelCreating(builder);
    }
}
