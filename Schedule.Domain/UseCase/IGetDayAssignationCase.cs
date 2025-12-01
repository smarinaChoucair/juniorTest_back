namespace Schedule.Domain.UseCase;

public interface IGetDayAssignationCase
{
    Task<string?> GetMealAssign(string dayName);
}