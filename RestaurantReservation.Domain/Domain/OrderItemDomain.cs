namespace RestaurantReservation.Domain.Domain
{
    public class OrderItemDomain
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public OrderDomain Order { get; set; }
        public MenuItemDomain Item { get; set; }
    }
}
