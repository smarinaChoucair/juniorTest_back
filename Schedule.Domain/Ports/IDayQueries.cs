namespace Schedule.Domain.Ports;

public interface IDayQueries
{
    Task<Entities.Day?> GetByName(string dayName);
}
