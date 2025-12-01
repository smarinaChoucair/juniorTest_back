using Microsoft.AspNetCore.Mvc;
using Schedule.Common.DTOs;
using Schedule.Domain.UseCase;

namespace Schedule.Web.Controllers;

[ApiController]
public class ScheduleController : ControllerBase
{
    private readonly ICreateMealCase _createMealCase;
    private readonly IAssingMealCase _assingMealCase;
    private readonly IGetDayAssignationCase _getDayAssignationCase;
    private readonly IGetAllWeekIngredients _getAllWeekIngredients;
    private readonly IGetAllMealsCase _getAllMealsCase;

    public ScheduleController
    (
        ICreateMealCase createMealCase,
        IAssingMealCase assingMealCase,
        IGetDayAssignationCase getDayAssignationCase,
        IGetAllWeekIngredients getAllWeekIngredients,
        IGetAllMealsCase getAllMealsCase
    )
    {
        _createMealCase = createMealCase;
        _assingMealCase = assingMealCase;
        _getDayAssignationCase = getDayAssignationCase;
        _getAllWeekIngredients = getAllWeekIngredients;
        _getAllMealsCase = getAllMealsCase;
    }


    [HttpPost("/meals")]
    public async Task<CreateMealResponseDto> CreateMeal([FromBody] CreateMealDto dto)
    {
        var result = await _createMealCase.CreateNewMealCase(dto);
        return result;
    }


    [HttpPut("/meals/{id}/assign-day")]
    public async Task<AssignationResponseDto> AssingMeal([FromRoute] int id, [FromBody] AssingExistingMealDto dto)
    {
        var result = await _assingMealCase.AssingMealCase(id, dto.DayName);
        return result;
    }


    [HttpGet("/meals/{dayName}")]
    public async Task<string> GetAssignation([FromRoute] string dayName)
    {
        var meal = await _getDayAssignationCase.GetMealAssign(dayName);
        return meal;
    }


    [HttpGet("/ingredients/summary")]
    public async Task<GetIngredientsListDto> GetIngredientsList()
    {
        var result = await _getAllWeekIngredients.GetAllIngredientsCase();
        return result;
    }


    [HttpGet("/meals/all")]
    public async Task<MealsListDto> GetAllAvailableMeals()
    {
        var result = await _getAllMealsCase.GetAllMeals();
        return result;
    }
}
