namespace Schedule.Infrastructure.Database.Entities;

public class Day
{
    public int DayId { get; set; }
    public string DayName { get; set; } = null!;


    public ICollection<Assignation> Assignation { get; set; } = new List<Assignation>();
}
