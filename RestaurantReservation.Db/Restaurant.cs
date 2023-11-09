using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class Restaurant: OpeningHours
    {
        [Key]
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Table> Tables { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
