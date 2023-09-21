using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db
{
    public class MenuItem
    {
        [Key]
        public int item_id { get; set; }
        public int restaurant_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public Restaurant restaurant { get; set; }
        public OrderItem orderItem { get; set; }
    }
}
