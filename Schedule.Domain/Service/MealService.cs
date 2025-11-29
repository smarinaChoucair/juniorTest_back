using Schedule.Common.DTOs;
using Schedule.Infrastructure.Database.Entities;
using Schedule.Infrastructure.Repositories.MealRepository;

namespace Schedule.Domain.Service;

public class MealService : IMealService
{
    private readonly ICreateMealRepository _createMealRepository;
    private readonly IGetMealByIdRepository _getMealByIdRepository;
    private readonly IGetAllMealsRepository _getAllMealsRepository;


    public MealService
    (
        ICreateMealRepository createMealRepository,
        IGetMealByIdRepository getMealByIdRepository,
        IGetAllMealsRepository getAllMealsRepository
    )
    {
        _createMealRepository = createMealRepository;
        _getMealByIdRepository = getMealByIdRepository;
        _getAllMealsRepository = getAllMealsRepository;
    }


    public async Task<Meal> CreateMealService(CreateMealDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.MealName))
            throw new Exception("Nombre del plato es requerido.");

        if (dto.MealIngredients == null || dto.MealIngredients.Count == 0 || dto.MealIngredients.All(x => string.IsNullOrWhiteSpace(x)))
            throw new Exception("Debe tener al menos 1 ingrediente.");

        var MealSchema = new Meal
        {
            MealName = dto.MealName,
            MealIngredients = dto.MealIngredients
        };

        var response = await _createMealRepository.CreateNewMeal(MealSchema);

        return response;
    }


    public async Task<Meal> GetMealById(int id)
    {
        var meal = await _getMealByIdRepository.GetMealById(id);

        if (meal == null)
            throw new Exception($"Plato con id {id} no existe");

        return meal;
    }


    public async Task<List<Meal>> GetAllMeals()
    {
        var meals = await _getAllMealsRepository.GetAllMeals();
        return meals;
    }
}
