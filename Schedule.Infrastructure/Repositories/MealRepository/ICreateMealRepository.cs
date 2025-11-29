using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public interface ICreateMealRepository
{
    Task<Meal> CreateNewMeal(Meal entity);
}