using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.EntityClass
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }
        public int restaurant_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public EmployeePosition position { get; set; }
        public Restaurant restaurant { get; set; }
        public ICollection<Order> orders { get; set; }

    }
}