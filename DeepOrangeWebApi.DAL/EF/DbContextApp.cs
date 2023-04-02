using DeepOrangeWebApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace DeepOrangeWebApi.DAL.EF;
public class DbContextApp : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Direction> Directions { get; set; }

    public DbContextApp(DbContextOptions<DbContextApp> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Technology>()
            .HasOne(t => t.Direction)
            .WithMany(d => d.Technologies)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Employee>()
            .HasMany(e => e.Technologies)
            .WithMany(t => t.Employees)
            .UsingEntity(j => j.ToTable("EmployeeTechnologies"));

        base.OnModelCreating(builder);
    }
}
