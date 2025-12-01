using Schedule.Common.DTOs;
using Schedule.Domain.Ports;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class AssignMealCase : IAssingMealCase
{
    private readonly ICheckMealExistanceService _checkMealExistanceService;
    private readonly IGetDayByNameService _getDayByNameService;

    private readonly IUnitOfWork _uow;

    public AssignMealCase
    (
        ICheckMealExistanceService checkMealExistanceService,
        IGetDayByNameService getDayByNameService,
        IUnitOfWork uow
    )
    {
        _checkMealExistanceService = checkMealExistanceService;
        _getDayByNameService = getDayByNameService;
        _uow = uow;
    }


    public async Task<AssignationResponseDto> AssingMealCase(int mealId, string dayName)
    {
        var meal = await _checkMealExistanceService.Exists(mealId);
        
        var day = await _getDayByNameService.GetDayByName(dayName);
        if (day.AssignedMeal != null)
            throw new Exception($"Día {dayName} ya tiene un plato asignado.");

        day.AssignedMeal = meal;
        await _uow.SaveChangesAsync();

        return new AssignationResponseDto
        {
            DayId = day.DayId,
            AssignationDay = $"Plato con id '{meal}' asignado exitosamente al día '{day.DayName}'."
        };
    }
}
