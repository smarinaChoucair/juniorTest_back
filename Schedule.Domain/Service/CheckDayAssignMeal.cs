using Schedule.Domain.Ports;

namespace Schedule.Domain.Service;

public class CheckDayAssignMeal : ICheckDayAssignMeal
{
    private readonly IDayChecks _dayChecks;

    public CheckDayAssignMeal
    (
        IDayChecks dayChecks
    )
    {
        _dayChecks = dayChecks;
    }


    public async Task<bool> Check(string dayName)
    {
        var response = await _dayChecks.CheckDayExist(dayName);
        return response;
    }
}
