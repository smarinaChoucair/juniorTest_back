using Schedule.Common.DTOs;
using Schedule.Domain.Entities;

namespace Schedule.Domain.Service;

public interface ICreateMealService
{
    Task<int> Create(CreateMealDto dto);
}