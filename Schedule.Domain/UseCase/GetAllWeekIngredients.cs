using Schedule.Common.DTOs;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class GetAllWeekIngredients : IGetAllWeekIngredients
{
    private readonly IGetDayByNameService _getDayByNameService;
    private readonly IGetMealByIdService _getMealByIdService;

    public GetAllWeekIngredients
    (
        IGetDayByNameService getDayByNameService,
        IGetMealByIdService getMealByIdService
    )
    {
        _getDayByNameService = getDayByNameService;
        _getMealByIdService = getMealByIdService;
    }


    public async Task<GetIngredientsListDto> GetAllIngredientsCase()
    {
        List<string> dayist = ["monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"];

        var ingredientList = new List<string>();

        foreach (string day in dayist)
        {
            var assignation = await _getDayByNameService.GetDayByName(day);

            if (assignation.AssignedMeal != null)
            {
                var mealId = assignation.AssignedMeal.Value;
                if (mealId <= 0)
                    continue;

                var meal = await _getMealByIdService.GetById(mealId);
                if (meal?.MealIngredients != null)
                {
                    {
                        foreach (var entry in meal.MealIngredients)
                        {
                            if (string.IsNullOrWhiteSpace(entry)) continue;

                            var parts = entry
                                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                            ingredientList.AddRange(parts);
                        }
                    }
                }
            }
        }

        if (ingredientList.Count == 0)
        {
            throw new Exception("No hay ingredientes registrados para esta semana.");
        }

        var distinctIngredients = ingredientList
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        return new GetIngredientsListDto
        {
            Ingredientes = distinctIngredients
        };
    }
}
