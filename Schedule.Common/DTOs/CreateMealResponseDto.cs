namespace Schedule.Common.DTOs;

public class CreateMealResponseDto
{
    public string ResponseMessage { get; set; } = null!;
    public string? DayAssigned {  get; set; }
}
