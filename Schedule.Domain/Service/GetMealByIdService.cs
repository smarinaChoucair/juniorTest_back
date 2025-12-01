using Schedule.Domain.Entities;
using Schedule.Domain.Ports;

namespace Schedule.Domain.Service;

public class GetMealByIdService : IGetMealByIdService
{
    private readonly IMealQueries _mealQueries;


    public GetMealByIdService
    (
        IMealQueries mealQueries
    )
    {
        _mealQueries = mealQueries;
    }


    public async Task<Meal> GetById(int id)
    {
        var meal = await _mealQueries.GetById(id);

        if (meal == null)
            throw new Exception($"Plato con id {id} no existe");

        return meal;
    }
}
