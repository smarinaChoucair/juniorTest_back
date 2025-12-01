using Schedule.Domain.Entities;
using Schedule.Domain.Ports;

namespace Schedule.Domain.Service;

public class GetDayByNameService : IGetDayByNameService
{
    private readonly IDayQueries _dayQueries;

    public GetDayByNameService
    (
        IDayQueries dayQueries
    )
    {
        _dayQueries = dayQueries;
    }


    public async Task<Day> GetDayByName(string dayName)
    {
        var normalizedDayName = dayName.Trim().ToLower();

        var day = await _dayQueries.GetByName(normalizedDayName);

        if ( day == null )
        {
            throw new Exception($"El día '{dayName}' no existe.");
        }

        return day;
    }
}
