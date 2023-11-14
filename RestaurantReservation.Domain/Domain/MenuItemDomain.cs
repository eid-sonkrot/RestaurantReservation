namespace RestaurantReservation.Domain.Domain
{
    public class MenuItemDomain
    {
        public int ItemId { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public RestaurantDomain Restaurant { get; set; }
        public ICollection<OrderItemDomain> OrderItems { get; set; } = new List<OrderItemDomain>();
    }
}