namespace RestaurantReservation.Business.DomainClass
{
    public class TableDomain
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public int Capacity { get; set; }
        public RestaurantDomain Restaurant { get; set; }
        public ICollection<ReservationDomain> Reservations { get; set; }
    }
}