using Schedule.Common.DTOs;

namespace Schedule.Domain.UseCase;

public interface ICreateMealCase
{
    Task<CreateMealResponseDto> CreateNewMealCase(CreateMealDto dto);
}
