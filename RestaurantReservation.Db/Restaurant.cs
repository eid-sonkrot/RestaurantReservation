using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class Restaurant
    {
        [Key]
        public int restaurant_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public OpeningHours opening_hours { get; set; }
        public ICollection<Reservation> reservations { get; set; }
        public ICollection<Table> tables { get; set; }
        public ICollection<MenuItem> menuItems { get; set; }
        public ICollection<Employee> employees { get; set; }

    }
}
