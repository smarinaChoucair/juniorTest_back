using Microsoft.EntityFrameworkCore;
using Schedule.Infrastructure.Database.Context;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public class GetAllMealsRepository : IGetAllMealsRepository
{
    private readonly ScheduleContext _context;

    public GetAllMealsRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<List<Meal>> GetAllMeals()
    {
        var query = await _context.Meal
            .AsNoTracking()
            .ToListAsync();

        return query;
    }
}
