using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.DTO
{
    public class RestaurantDTO
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
