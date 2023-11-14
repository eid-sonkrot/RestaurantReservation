using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db
{
    public class OpeningHours
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}