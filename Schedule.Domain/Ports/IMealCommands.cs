using Schedule.Domain.Entities;

namespace Schedule.Domain.Ports;

public interface IMealCommands
{
    Task Create(Meal meal);
}
