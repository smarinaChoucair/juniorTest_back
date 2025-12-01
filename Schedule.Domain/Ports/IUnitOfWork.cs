using Schedule.Domain.Entities;

namespace Schedule.Domain.Ports;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
