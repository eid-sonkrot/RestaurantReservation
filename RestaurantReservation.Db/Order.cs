using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db
{
    public class Order
    {
        [Key]
        public int order_id {  get; set; }
        public int reservation_id { get; set; }
        public int employee_id { get; set; }
        public DateTime order_date { get; set; }
        public double total_amount { get; set; }
        public Reservation reservation { get; set; }
        public Employee employee { get; set; }
        public ICollection<OrderItem> items { get; set; }

    }
}