namespace Schedule.Infrastructure.Database.Entities;

public class Meal
{
    public int MealId { get; set; }
    public string MealName { get; set; } = null!;
    public List<string> MealIngredients { get; set; } = null!;


    public ICollection<Assignation> Assignation { get; set; } = new List<Assignation>();
}
