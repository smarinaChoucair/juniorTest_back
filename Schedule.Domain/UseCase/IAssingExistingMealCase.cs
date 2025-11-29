using Schedule.Common.DTOs;

namespace Schedule.Domain.UseCase;

public interface IAssingExistingMealCase
{
    Task<AssignationResponseDto> AssingMealCase(int id, AssingExistingMealDto dto);
}
