namespace RestaurantReservation.ApplicationLayer.DTO
{
    public class RestaurantDTO
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public OpeningHoursDomain OpeningHours { get; set; }
    }
}