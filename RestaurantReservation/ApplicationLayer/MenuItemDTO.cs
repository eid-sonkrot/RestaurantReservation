namespace RestaurantReservation.ApplicationLayer
{
    public class MenuItemDTO
    {
        public int ItemId { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}