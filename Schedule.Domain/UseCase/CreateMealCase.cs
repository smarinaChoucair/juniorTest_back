using Schedule.Common.DTOs;
using Schedule.Domain.Service;

namespace Schedule.Domain.UseCase;

public class CreateMealCase : ICreateMealCase
{
    private readonly ICreateMealService _createMealService;
    private readonly IGetDayByNameService _getDayByNameService;
    private readonly IAssingMealCase _assingExistingMealCase;

    public CreateMealCase
    (
        ICreateMealService createMealService,
        IGetDayByNameService getDayByNameService,
        IAssingMealCase assingExistingMealCase
    )
    {
        _createMealService = createMealService;
        _getDayByNameService = getDayByNameService;
        _assingExistingMealCase = assingExistingMealCase;
    }


    public async Task<CreateMealResponseDto> CreateNewMealCase(CreateMealDto dto)
    {
        if (dto.DayName != null)
        {
            var day = await _getDayByNameService.GetDayByName(dto.DayName);

            if (day.AssignedMeal != null )
                throw new Exception($"Dia {day.DayName} ya tiene un plato seleccionado");

            var mealId = await _createMealService.Create(dto);

            var assignation = await _assingExistingMealCase.AssingMealCase(mealId, day.DayName);

            var response = new CreateMealResponseDto
            {
                ResponseMessage = "Plato creado exitosamente",
                DayAssigned = $"Registrado para el día {day.DayName}"
            };

            return response;
        }

        var CreatedMeal = await _createMealService.Create(dto);
        var commonResponse = new CreateMealResponseDto
        {
            ResponseMessage = "Plato creado exitosamente"
        };

        return commonResponse;
    }
}
