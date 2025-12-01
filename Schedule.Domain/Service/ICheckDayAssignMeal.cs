namespace Schedule.Domain.Service;

public interface ICheckDayAssignMeal
{
    Task<bool> Check(string dayName);
}
