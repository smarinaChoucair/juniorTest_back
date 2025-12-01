using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Ports;
using Schedule.Infrastructure.Database.Context;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public class MealChecksRepository : IMealCheck
{
    private readonly ScheduleContext _context;

    public MealChecksRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<bool> ExistsById(int mealId)
    {
        var exists = await _context.Meal
            .Where(m => m.MealId == mealId)
            .AnyAsync();

        if (!exists)
            return false;

        return true;
    }
}
