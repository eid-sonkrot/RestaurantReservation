namespace RestaurantReservation.Db
{
    public class ReservationView
    {
        public Reservation Reservation { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
