namespace RestaurantReservation.Domain.Domain
{
    public class EmployeeDomain
    {
        public int EmployeeId { get; set; }
        public int RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeePositionDomain Position { get; set; }
        public RestaurantDomain Restaurant { get; set; }
        public ICollection<OrderDomain> Orders { get; set; } = new List<OrderDomain>();
    }
}