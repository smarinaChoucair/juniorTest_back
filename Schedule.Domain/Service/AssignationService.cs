using Schedule.Common.DTOs;
using Schedule.Infrastructure.Database.Entities;
using Schedule.Infrastructure.Repositories.AssignationRepository;

namespace Schedule.Domain.Service;

public class AssignationService : IAssignationService
{
    private readonly ICreateAssignationRepository _createAssignationRepository;
    private readonly IGetAssignatedDaysByIdRepository _readAssignatedDayByDataRepository;

    public AssignationService
    (
        ICreateAssignationRepository createAssignationRepository,
        IGetAssignatedDaysByIdRepository readAssignatedDaysRepository
    )
    {
        _createAssignationRepository = createAssignationRepository;
        _readAssignatedDayByDataRepository = readAssignatedDaysRepository;
    }


    public async Task<AssignationResponseDto> AssignateMealToDay(int Meal, int Day)
    {
        var AssignationSchema = new Assignation
        {
            MealId = Meal,
            DayId = Day
        };

        var response = await _createAssignationRepository.CreateNewAssignation(AssignationSchema);

        var responseMessage = new AssignationResponseDto
        {
            DayId = response.DayId,
            AssignationMessage = $"Plato creado exitosamente para el día {response.DayId}"
        };

        return responseMessage;
    }


    public async Task<Assignation?> ReadAssignatedDays(int DayId)
    {
        var response = await _readAssignatedDayByDataRepository.GetAssignedDaysById(DayId);
        return response;
    }
}
