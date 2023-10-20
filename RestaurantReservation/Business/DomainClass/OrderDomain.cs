namespace RestaurantReservation.Business.DomainClass
{
    public class OrderDomain
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public ReservationDomain Reservation { get; set; }
        public EmployeeDomain Employee { get; set; }
        public ICollection<OrderItemDomain> Items { get; set; }
    }
}
