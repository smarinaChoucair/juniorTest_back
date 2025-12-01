namespace Schedule.Domain.Entities;

public class Meal
{
    public int MealId { get; set; }
    public string MealName { get; set; } = null!;
    public List<string> MealIngredients { get; set; } = null!;


    public ICollection<Day> Day { get; set; } = new List<Day>();
}
