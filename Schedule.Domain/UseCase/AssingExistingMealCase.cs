using Schedule.Common.DTOs;
using Schedule.Common.Mapper;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class AssingExistingMealCase : IAssingExistingMealCase
{
    private readonly IAssignationService _assignationService;
    private readonly IMealService _mealService;

    public AssingExistingMealCase
    (
        IAssignationService assignationService,
        IMealService mealService
    )
    {
        _assignationService = assignationService;
        _mealService = mealService;
    }


    public async Task<AssignationResponseDto> AssingMealCase(int id, AssingExistingMealDto dto)
    {
        var dayId = DayMapper.ToDayId(dto.Day);

        var existingMeal = await _mealService.GetMealById(id);

        var assignation = await _assignationService.AssignateMealToDay(id, dayId);
        return assignation;
    }
}
