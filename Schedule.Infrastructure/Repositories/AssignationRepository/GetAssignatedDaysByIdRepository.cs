using Microsoft.EntityFrameworkCore;
using Schedule.Infrastructure.Database.Context;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.AssignationRepository;

public class GetAssignatedDaysByIdRepository : IGetAssignatedDaysByIdRepository
{
    private readonly ScheduleContext _context;

    public GetAssignatedDaysByIdRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<Assignation?> GetAssignedDaysById(int DayId)
    {
        var query = await _context.Assignation
            .Where(a => a.DayId == DayId)
            .FirstOrDefaultAsync();

        if ( query != null )
            return query;

        return null;
    }
}
