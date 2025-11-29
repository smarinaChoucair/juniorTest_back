namespace Schedule.Common.DTOs;

public class CreateMealDto
{
    public string MealName { get; set; } = null!;
    public List<string> MealIngredients { get; set; } = new();
    public string? DayName { get; set; }
}
