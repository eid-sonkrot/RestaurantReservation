namespace RestaurantReservation.Domain.Domain
{
    public class TableDomain
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public int capacity { get; set; }
        public RestaurantDomain Restaurant { get; set; }
        public ICollection<ReservationDomain> Reservations { get; set; } = new List<ReservationDomain>();
    }
}