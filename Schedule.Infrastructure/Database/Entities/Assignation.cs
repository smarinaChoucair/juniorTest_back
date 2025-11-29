namespace Schedule.Infrastructure.Database.Entities;

public class Assignation
{
    public int AssignationId { get; set; }
    public int DayId { get; set; }
    public int MealId { get; set; }


    public Day Day { get; set; } = null!;
    public Meal Meal { get; set; } = null!;
}
