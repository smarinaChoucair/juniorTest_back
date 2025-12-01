using Schedule.Domain.Ports;
using Schedule.Infrastructure.Database.Context;

namespace Schedule.Infrastructure.Repositories.UoWRepository;

public class UnitOfWork : IUnitOfWork
{

    private readonly ScheduleContext _context;

    public UnitOfWork
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
