using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db
{
    public class Table
    {
        [Key]
        public int table_id { get; set; }
        public int restaurant_id { get; set; }
        public int capacity { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public Restaurant restaurant { get; set; }
    }
}