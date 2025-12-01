using Schedule.Common.DTOs;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class GetAllMealsCase : IGetAllMealsCase
{
    private readonly IGetAllMealsService _getAllMealsService;
    public GetAllMealsCase
    (
        IGetAllMealsService getAllMealsService
    )
    {
        _getAllMealsService = getAllMealsService;
    }


    public async Task<MealsListDto> GetAllMeals()
    {
        var meals = await _getAllMealsService.GetAll();

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
