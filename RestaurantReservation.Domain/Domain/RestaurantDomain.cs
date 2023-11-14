namespace RestaurantReservation.Domain.Domain
{
    public class RestaurantDomain: OpeningHoursDomain
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ReservationDomain> Reservations { get; set; } = new List<ReservationDomain>();
        public ICollection<TableDomain> Tables { get; set; } = new List<TableDomain>();
        public ICollection<MenuItemDomain> MenuItems { get; set; } = new List<MenuItemDomain>();
        public ICollection<EmployeeDomain> Employees { get; set; } = new List<EmployeeDomain>();
    }
}