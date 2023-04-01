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


        builder.Entity<Direction>().HasData(new Direction()
        {
            DirectionId = 1,
            DirectionName = "PHP"
        });

        builder.Entity<Direction>().HasData(new Direction()
        {
            DirectionId = 2,
            DirectionName = "Python"
        });

        builder.Entity<Technology>().HasData(new Technology()
        {
            TechnologyId = 1,
            TechnologyName = "Magento",
            DirectionId = 1
        });

        builder.Entity<Technology>().HasData(new Technology()
        {
            TechnologyId = 2,
            TechnologyName = "Flask",
            DirectionId = 2
        });

        builder.Entity<Technology>().HasData(new Technology()
        {
            TechnologyId = 3,
            TechnologyName = "NumPy",
            DirectionId = 2
        });

        builder.Entity<Employee>().HasData(new Employee()
        {
            EmployeeId = 1,
            Name = "Mykyta",
            LastName = "Honcharov",
        });

        builder.Entity<Employee>().HasMany(e => e.Technologies).WithMany(t => t.Employees).UsingEntity(j => j.HasData(
            new { EmployeesEmployeeId = 1, TechnologiesTechnologyId = 1 },
            new { EmployeesEmployeeId = 1, TechnologiesTechnologyId = 2 },
            new { EmployeesEmployeeId = 1, TechnologiesTechnologyId = 3 }
        ));

        base.OnModelCreating(builder);
    }
}
