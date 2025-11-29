using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.AssignationRepository;

public interface IGetAssignatedDaysByIdRepository
{
    Task<Assignation?> GetAssignedDaysById(int DayId);
}
