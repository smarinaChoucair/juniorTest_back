using Schedule.Common.DTOs;

namespace Schedule.Domain.UseCase;

public interface IGetAllMealsCase
{
    Task<MealsListDto> GetAllMeals();
}