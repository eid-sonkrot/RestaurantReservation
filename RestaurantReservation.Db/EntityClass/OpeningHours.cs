using Microsoft.EntityFrameworkCore;

public record OpeningHours
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}