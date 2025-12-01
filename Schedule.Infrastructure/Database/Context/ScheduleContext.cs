using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Schedule.Infrastructure.Database.Configuration;
using Schedule.Domain.Entities;

namespace Schedule.Infrastructure.Database.Context;

public class ScheduleContext : DbContext
{
    private readonly IConfiguration _configuration;

    public virtual DbSet<Meal> Meal { get; set; }
    public virtual DbSet<Day> Day { get; set; }


    public ScheduleContext(DbContextOptions<ScheduleContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MealConfiguration());
        modelBuilder.ApplyConfiguration(new DayConfiguration());
    }
}
