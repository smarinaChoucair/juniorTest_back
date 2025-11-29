using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Infrastructure.Database.Entities;
using System.Text.Json;

namespace Schedule.Infrastructure.Database.Configuration;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("Meals");

        builder.HasKey(m => m.MealId);
        builder.Property(m => m.MealId)
            .ValueGeneratedOnAdd();

        builder.Property(m => m.MealName)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(m => m.MealIngredients)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>()
            )
            .HasColumnType("nvarchar(max)")
            .IsRequired();
    }
}
