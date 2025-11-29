namespace Schedule.Common.Mapper;

public static class DayMapper
{
    private static readonly Dictionary<string, int> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["monday"] = 1,
        ["tuesday"] = 2,
        ["wednesday"] = 3,
        ["thursday"] = 4,
        ["friday"] = 5,
        ["saturday"] = 6,
        ["sunday"] = 7
    };

    public static int ToDayId(string day)
    {
        if (string.IsNullOrWhiteSpace(day))
            throw new Exception("El día es obligatorio.");

        var key = day.Trim().ToLowerInvariant();

        if (!Map.TryGetValue(key, out var id))
            throw new Exception("Día solicitado no existe.");

        return id;
    }
}
