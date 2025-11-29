using Schedule.Common.DTOs;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class GetAllWeekIngredients : IGetAllWeekIngredients
{
    private readonly IAssignationService _assignationService;
    private readonly IMealService _mealService;

    public GetAllWeekIngredients
    (
        IAssignationService assignationService,
        IMealService mealService
    )
    {
        _assignationService = assignationService;
        _mealService = mealService;
    }


    public async Task<GetIngredientsListDto> GetAllIngredientsCase()
    {
        List<int> dayIdList = [1, 2, 3, 4, 5, 6, 7];

        var ingredientList = new List<string>();

        foreach ( int dayId in dayIdList)
        {
            var assignation = await _assignationService.ReadAssignatedDays( dayId );

            if ( assignation != null)
            {
                var mealId = assignation.MealId;

                var meal = await _mealService.GetMealById( mealId );
                if (meal?.MealIngredients != null)
                    ingredientList.AddRange(meal.MealIngredients);
            }
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
