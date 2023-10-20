namespace RestaurantReservation.Business.DomainClass
{
    public class ReservationDomain
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public Customer Customer { get; set; }
        public RestaurantDomain Restaurant { get; set; }
        public TableDomain Table { get; set; }
        public OrderDomain Orders { get; set; }
    }
}