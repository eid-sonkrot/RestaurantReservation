using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class OrderItem
    {
        [Key]
        [Column("order_item_id")]
        public int OrderItemId { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("item_id")]
        public int ItemId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public MenuItem Item { get; set; }
    }
}