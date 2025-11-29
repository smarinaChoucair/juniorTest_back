using Schedule.Common.DTOs;
using Schedule.Common.Mapper;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class CreateMealCase : ICreateMealCase
{
    private readonly IMealService _mealService;
    private readonly IAssignationService _assignationService;

    public CreateMealCase
    (
        IMealService mealService,
        IAssignationService assignationService
    )
    {
        _mealService = mealService;
        _assignationService = assignationService;
    }


    public async Task<CreateMealResponseDto> CreateNewMealCase(CreateMealDto dto)
    {
        if (dto.DayName != null)
        {
            int dayId = DayMapper.ToDayId(dto.DayName);
            var exists = await _assignationService.ReadAssignatedDays(dayId);

            if (exists != null)
                throw new Exception($"Dia {exists.DayId} ya tiene un plato seleccionado");

            var meal = await _mealService.CreateMealService(dto);
            var assignation = await _assignationService.AssignateMealToDay(meal.MealId, dayId);

            var response = new CreateMealResponseDto
            {
                ResponseMessage = "Plato creado exitosamente",
                DayAssigned = $"Registrado para el día {dto.DayName}"
            };

            return response;
        }


        var CreatedMeal = await _mealService.CreateMealService(dto);
        var commonResponse = new CreateMealResponseDto
        {
            ResponseMessage = "Plato creado exitosamente"
        };

        return commonResponse;
    }
}
