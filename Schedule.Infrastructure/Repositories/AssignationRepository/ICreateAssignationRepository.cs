using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Infrastructure.Repositories.AssignationRepository;

public interface ICreateAssignationRepository
{
    Task<Assignation> CreateNewAssignation(Assignation entity);
}