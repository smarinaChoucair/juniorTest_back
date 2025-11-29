using Schedule.Common.DTOs;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class GetAllMealsCase : IGetAllMealsCase
{
    private readonly IMealService _mealService;
    public GetAllMealsCase
    (
        IMealService mealService
    )
    {
        _mealService = mealService;
    }


    public async Task<MealsListDto> GetAllMeals()
    {
        var meals = await _mealService.GetAllMeals();

        var mealList = new MealsListDto
        {
            Meals = meals.Select(m => new MealDto
            {
                Id = m.MealId,
                Name = m.MealName,
                Ingredients = m.MealIngredients
            }).ToList()
        };

        return mealList;
    }
}
