using Schedule.Infrastructure.Database.Context;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.AssignationRepository;

public class CreateAssignationRepository : ICreateAssignationRepository
{
    private readonly ScheduleContext _context;

    public CreateAssignationRepository
    (
        ScheduleContext context
    )
    {
        _context = context;
    }


    public async Task<Assignation> CreateNewAssignation(Assignation entity)
    {
        _context.Assignation.Add( entity );

        var rows = await _context.SaveChangesAsync();
        if (rows <= 0)
            throw new Exception($"No se pudo asignar el plato");

        return entity;
    }
}
