using Schedule.Common.DTOs;
using Schedule.Infrastructure.Database.Entities;

namespace Schedule.Domain.Service;

public interface IAssignationService
{
    Task<AssignationResponseDto> AssignateMealToDay(int Meal, int Day);
    Task<Assignation?> ReadAssignatedDays(int DayId);
}
