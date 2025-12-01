namespace Schedule.Domain.Service;

public interface ICheckMealExistanceService
{
    Task<int> Exists(int mealId);
}