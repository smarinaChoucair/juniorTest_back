using Schedule.Domain.Entities;
using Schedule.Domain.Ports;

namespace Schedule.Domain.Service;

public class GetAllMealsService : IGetAllMealsService
{
    private readonly IMealQueries _mealQueries;


    public GetAllMealsService
    (
        IMealQueries mealQueries
    )
    {
        _mealQueries = mealQueries;
    }


    public async Task<List<Meal>> GetAll()
    {
        var meals = await _mealQueries.GetAll();
        return meals;
    }
}
