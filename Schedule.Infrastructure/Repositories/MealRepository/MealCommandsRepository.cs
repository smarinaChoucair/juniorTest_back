using Schedule.Infrastructure.Database.Context;
using Schedule.Domain.Entities;
using Schedule.Domain.Ports;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public class MealCommandsRepository : IMealCommands
{
    private readonly ScheduleContext _context;

    public MealCommandsRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public Task Create(Meal meal)
    {
        _context.Meal.Add(meal);
        return Task.CompletedTask;
    }
}
