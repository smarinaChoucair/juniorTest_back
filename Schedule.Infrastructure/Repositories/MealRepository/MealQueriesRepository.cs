using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Entities;
using Schedule.Domain.Ports;
using Schedule.Infrastructure.Database.Context;

namespace Schedule.Infrastructure.Repositories.MealRepository;

public class MealQueriesRepository : IMealQueries
{
    private readonly ScheduleContext _context;

    public MealQueriesRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<Meal?> GetById(int id)
    {
        var meal = await _context.Meal
            .Where(m => m.MealId == id)
            .FirstOrDefaultAsync();

        return meal;
    }


    public async Task<List<Meal>> GetAll()
    {
        
        var query = await _context.Meal
            .AsNoTracking()
            .ToListAsync();

        return query;
    }
}
