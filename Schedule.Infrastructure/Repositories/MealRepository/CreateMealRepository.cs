using Schedule.Infrastructure.Database.Context;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public class CreateMealRepository : ICreateMealRepository
{
    private readonly ScheduleContext _context;

    public CreateMealRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<Meal> CreateNewMeal(Meal entity)
    {
        await _context.Meal.AddAsync(entity);

        var rows = await _context.SaveChangesAsync();
        if (rows <= 0)
            throw new Exception("No se pudo crear el plato");

        return entity;
    }
}
