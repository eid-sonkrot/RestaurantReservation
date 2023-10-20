namespace RestaurantReservation.Business.DomainClass
{
    public class CustomerDomain
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<ReservationDomain> Reservations { get; set; }
    }
}
