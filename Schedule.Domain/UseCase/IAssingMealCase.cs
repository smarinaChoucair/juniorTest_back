using Schedule.Common.DTOs;

namespace Schedule.Domain.UseCase;

public interface IAssingMealCase
{
    Task<AssignationResponseDto> AssingMealCase(int mealId, string dayName);
}
