using Schedule.Common.DTOs;

namespace Schedule.Domain.UseCase;

public interface IGetAllWeekIngredients
{
    Task<GetIngredientsListDto> GetAllIngredientsCase();
}