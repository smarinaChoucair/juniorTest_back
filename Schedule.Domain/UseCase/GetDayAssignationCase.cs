using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class GetDayAssignationCase : IGetDayAssignationCase
{
    private readonly IGetDayByNameService _getDayByNameService;
    private readonly IGetMealByIdService _getMealByIdService;

    public GetDayAssignationCase
    (
        IGetDayByNameService getDayByNameService,
        IGetMealByIdService getMealByIdService
    )
    {
        _getDayByNameService = getDayByNameService;
        _getMealByIdService = getMealByIdService;
    }


    public async Task<string?> GetMealAssign(string dayName)
    {
        var day = await _getDayByNameService.GetDayByName(dayName);

        if (day != null)
        {
            var assignatedMeal = day.AssignedMeal;

            if (assignatedMeal == null)
                return null;

            var meal = await _getMealByIdService.GetById(assignatedMeal.Value);
            return meal.MealName.ToString();
        }

        return null;
    }
}
