namespace Schedule.Domain.Ports;

public interface IDayChecks
{
    Task<bool> CheckDayExist(string dayName);
}
