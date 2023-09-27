namespace RestaurantReservation.ApplicationLayer
{
    public class TableDTO
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public int Capacity { get; set; }
    }
}