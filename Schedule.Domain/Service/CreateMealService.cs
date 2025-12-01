using Schedule.Common.DTOs;
using Schedule.Domain.Entities;
using Schedule.Domain.Ports;

namespace Schedule.Domain.Service;

public class CreateMealService: ICreateMealService
{
    private readonly IMealCommands _mealCommands;
    private readonly IUnitOfWork _uow;


    public CreateMealService
    (
        IMealCommands mealCommands,
        IUnitOfWork uow

    )
    {
        _mealCommands = mealCommands;
        _uow = uow;
    }


    public async Task<int> Create(CreateMealDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.MealName))
            throw new Exception("Nombre del plato es requerido.");

        if (dto.MealIngredients == null || dto.MealIngredients.Count == 0 || dto.MealIngredients.All(x => string.IsNullOrWhiteSpace(x)))
            throw new Exception("Debe tener al menos 1 ingrediente.");

        var ingredients = dto.MealIngredients
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .ToList();

        var meal = new Meal
        {
            MealName = dto.MealName,
            MealIngredients = ingredients
        };

        await _mealCommands.Create(meal);
        await _uow.SaveChangesAsync();

        return meal.MealId;
    }
}
