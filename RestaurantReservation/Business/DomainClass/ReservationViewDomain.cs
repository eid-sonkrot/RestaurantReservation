namespace RestaurantReservation.Business.DomainClass
{
    public class ReservationViewDomain
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public Customer Customer { get; set; }
        public RestaurantDomain Restaurant { get; set; }

    }
}