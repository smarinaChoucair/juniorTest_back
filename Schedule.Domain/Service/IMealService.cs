using Schedule.Common.DTOs;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Domain.Service;

public interface IMealService
{
    Task<Meal> CreateMealService(CreateMealDto dto);
    Task<Meal> GetMealById(int id);
    Task<List<Meal>> GetAllMeals();
}