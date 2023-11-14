using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class Reservation
    {
        [Key]
        [Column("reservation_id")]
        public int ReservationId {get; set;}
        [Column("reservation_date")]
        public DateTime ReservationDate { get; set;}
        [Column("party_size")]
        public int PartySize {get; set;}
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        [Column("table_id")]
        public int TableId { get; set; }
        public Table Table { get; set; } 
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}