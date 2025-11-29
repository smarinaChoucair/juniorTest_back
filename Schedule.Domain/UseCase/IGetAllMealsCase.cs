using Schedule.Common.DTOs;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Domain.UseCase;

public interface IGetAllMealsCase
{
    Task<MealsListDto> GetAllMeals();
}