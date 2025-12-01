using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Ports;
using Schedule.Infrastructure.Database.Context;

namespace Schedule.Infrastructure.Repositories.DayRepository;

public class DayChecksRepository : IDayChecks
{
    private readonly ScheduleContext _context;

    public DayChecksRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<bool> CheckDayExist(string dayName)
    {
        var day = await _context.Day
            .Where(d => d.DayName == dayName)
            .AnyAsync();

        if (!day)
        {
            return false;
        }
        return true;
    }
}
