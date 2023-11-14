using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db
{
    public class MenuItem
    {
        [Key]
        [Column("item_id")]
        public int ItemId { get; set; }
        [Column("restaurant_id")]
        public int RestaurantId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("price")]
        public double Price { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); 
    }
}