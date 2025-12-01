namespace Schedule.Domain.Ports;

public interface IMealCheck
{
    Task<bool> ExistsById(int mealId);
}
