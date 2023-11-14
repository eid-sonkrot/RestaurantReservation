namespace RestaurantReservation.API.DTO
{
    public class TableDTO
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public int capacity { get; set; }
    }
}
