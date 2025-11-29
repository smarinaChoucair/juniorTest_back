namespace Schedule.Common.DTOs;

public class MealsListDto
{
    public List<MealDto> Meals { get; set; } = new();
}

public class MealDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<string> Ingredients { get; set; } = null!;
}
