namespace Schedule.Domain.Entities;

public class Day
{
    public int DayId { get; set; }
    public string DayName { get; set; } = null!;
    public int? AssignedMeal { get; set; }

    public Meal? Meal { get; set; }
}
