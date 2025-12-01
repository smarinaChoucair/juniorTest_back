using Schedule.Domain.Entities;

namespace Schedule.Domain.Ports;

public interface IMealQueries
{
    Task<Meal?> GetById(int id);
    Task<List<Meal>> GetAll();
}
