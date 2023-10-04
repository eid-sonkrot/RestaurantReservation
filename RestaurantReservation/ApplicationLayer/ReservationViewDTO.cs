namespace RestaurantReservation.ApplicationLayer
{
    public class ReservationViewDTO
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public CustomerDTO Customer { get; set; }
        public RestaurantDTO Restaurant { get; set; }
    }
}