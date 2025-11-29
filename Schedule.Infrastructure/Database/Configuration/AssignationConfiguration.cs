using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Database.Configuration;

public class AssignationConfiguration : IEntityTypeConfiguration<Assignation>
{
    public void Configure(EntityTypeBuilder<Assignation> builder)
    {
        builder.ToTable("Assignation");

        builder.HasKey(a => a.AssignationId);
        builder.Property(a => a.AssignationId)
            .ValueGeneratedOnAdd();


        builder.HasIndex(a => a.DayId)
            .IsUnique();
        builder.Property(a => a.DayId);


        builder.HasIndex(a => a.MealId);
        builder.Property(a => a.MealId);


        builder.HasOne(a => a.Day)
            .WithMany(d => d.Assignation)
            .HasForeignKey(a => a.DayId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Meal)
            .WithMany(m => m.Assignation)
            .HasForeignKey(a => a.MealId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
