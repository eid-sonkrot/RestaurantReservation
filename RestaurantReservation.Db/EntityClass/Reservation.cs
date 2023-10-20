using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.EntityClass
{
    public class Reservation
    {
        [Key]
        public int reservation_id { get; set; }
        public int customer_id { get; set; }
        public int restaurant_id { get; set; }
        public int table_id { get; set; }
        public DateTime reservation_date { get; set; }
        public int party_size { get; set; }
        public Customer customer { get; set; }
        public Restaurant restaurant { get; set; }
        public Table table { get; set; }
        public Order orders { get; set; }
    }
}