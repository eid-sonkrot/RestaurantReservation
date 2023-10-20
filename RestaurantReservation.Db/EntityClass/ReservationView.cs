namespace RestaurantReservation.Db.EntityClass
{
    public class ReservationView
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}