using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.EntityClass
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}