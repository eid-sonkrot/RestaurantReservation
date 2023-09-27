using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db
{
    public class OrderItem
    {
        [Key]
        public int order_item_id { get; set; }
        public int order_id { get; set; }
        public int item_id { get; set; }    
        public int quantity { get; set; }
        public Order order { get; set; }
        public MenuItem item { get; set; }
    }
}