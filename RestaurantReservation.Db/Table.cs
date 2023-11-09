using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class Table
    {
        [Key]
        [Column("table_id")]
        public int TableId { get; set; }
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public int capacity { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public Restaurant Restaurant { get; set; }
    }
}
