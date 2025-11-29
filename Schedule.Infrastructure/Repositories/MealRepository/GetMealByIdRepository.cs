using Microsoft.EntityFrameworkCore;
using Schedule.Infrastructure.Database.Context;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public class GetMealByIdRepository : IGetMealByIdRepository
{
    private readonly ScheduleContext _context;

    public GetMealByIdRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<Meal?> GetMealById(int id)
    {
        var query = await _context.Meal
            .Where(m => m.MealId == id)
            .FirstOrDefaultAsync();

        if (query != null)
            return query;

        return null;
    }
}
