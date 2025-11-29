using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Database.Configuration;

public class DayConfiguration : IEntityTypeConfiguration<Day>
{
    public void Configure(EntityTypeBuilder<Day> builder)
    {
        builder.ToTable("Days");

        builder.HasKey(d => d.DayId);
        builder.Property(d => d.DayId)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.DayName)
            .IsRequired()
            .HasMaxLength(250);


        builder.HasData(
            new Day
            {
                DayId = 1,
                DayName = "monday"
            },
            new Day
            {
                DayId = 2,
                DayName = "tuesday"
            },
            new Day
            {
                DayId = 3,
                DayName = "wednesday"
            },
            new Day
            {
                DayId = 4,
                DayName = "thursday"
            },
            new Day
            {
                DayId = 5,
                DayName = "friday"
            },
            new Day
            {
                DayId = 6,
                DayName = "saturday"
            },
            new Day
            {
                DayId = 7,
                DayName = "sunday"
            }
        );
    }
}
