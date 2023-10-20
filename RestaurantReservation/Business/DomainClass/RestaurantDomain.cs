namespace RestaurantReservation.Business.DomainClass
{
    public class RestaurantDomain
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public OpeningHoursDomain OpeningHours { get; set; }
        public ICollection<ReservationDomain> Reservations { get; set; }
        public ICollection<TableDomain> Tables { get; set; }
        public ICollection<MenuItemDomain> MenuItems { get; set; }
        public ICollection<EmployeeDomain> Employees { get; set; }
    }
}