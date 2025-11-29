using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public interface IGetAllMealsRepository
{
    Task<List<Meal>> GetAllMeals();
}