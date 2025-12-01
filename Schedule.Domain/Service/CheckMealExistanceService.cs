using Schedule.Domain.Entities;
using Schedule.Domain.Ports;

namespace Schedule.Domain.Service;

public class CheckMealExistanceService : ICheckMealExistanceService
{
    private readonly IMealCheck _mealCheck;

    public CheckMealExistanceService
    (
        IMealCheck mealCheck
    )
    {
        _mealCheck = mealCheck;
    }


    public async Task<int> Exists(int mealId)
    {
        var exists = await _mealCheck.ExistsById(mealId);
        if (exists == false)
            throw new Exception($"Plato con id {mealId} no existe");

        return mealId;
    }
}
