using Schedule.Common.Mapper;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class GetDayAssignationCase : IGetDayAssignationCase
{
    private readonly IAssignationService _assignationService;
    private readonly IMealService _mealService;

    public GetDayAssignationCase
    (
        IAssignationService assignationService,
        IMealService mealService
    )
    {
        _assignationService = assignationService;
        _mealService = mealService;
    }


    public async Task<string> GetMealAssign(string dayName)
    {
        var dayId = DayMapper.ToDayId(dayName);
        var assignated = await _assignationService.ReadAssignatedDays(dayId);

        if (assignated != null)
        {
            var assignatedMeal = await _mealService.GetMealById(assignated.MealId);
            return assignatedMeal.MealName.ToString();
        }

        return "null";
    }
}
