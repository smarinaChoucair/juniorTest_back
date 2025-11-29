using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public interface IGetMealByIdRepository
{
    Task<Meal?> GetMealById(int id);
}