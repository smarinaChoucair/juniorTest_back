using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Entities;
using Schedule.Domain.Ports;
using Schedule.Infrastructure.Database.Context;

namespace Schedule.Infrastructure.Repositories.DayRepository;

public class DayQueriesRepository : IDayQueries
{
    private readonly ScheduleContext _context;

    public DayQueriesRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<Day?> GetByName(string dayName)
    {
        var day = await _context.Day
            .Where(d => d.DayName == dayName)
            .FirstOrDefaultAsync();

        return day;
    }
}
