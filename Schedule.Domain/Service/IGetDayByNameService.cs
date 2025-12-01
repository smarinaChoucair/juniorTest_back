using Schedule.Domain.Entities;

namespace Schedule.Domain.Service;

public interface IGetDayByNameService
{
    Task<Day> GetDayByName(string dayName);
}
