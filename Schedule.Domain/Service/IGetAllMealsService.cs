using Schedule.Domain.Entities;

namespace Schedule.Domain.Service;

public interface IGetAllMealsService
{
    Task<List<Meal>> GetAll();
}
