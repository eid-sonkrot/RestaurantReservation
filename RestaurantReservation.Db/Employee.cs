using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set;}
        public EmployeePosition Position { get; set; }
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}