using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId {  get; set; }
        [Column("reservation_id")]
        public int ReservationId { get; set; }
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [Column("order_date")]
        public DateTime OrderDate { get; set; }
        [Column("total_amount")]
        public double TotalAmount { get; set; }
        public Reservation Reservation { get; set; }
        public Employee Employee { get; set; }
        public OrderItem Item { get; set; }
    }
}