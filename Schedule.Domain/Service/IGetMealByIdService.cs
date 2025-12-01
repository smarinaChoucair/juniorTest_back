using Schedule.Domain.Entities;

namespace Schedule.Domain.Service;

public interface IGetMealByIdService
{
    Task<Meal> GetById(int id);
}
