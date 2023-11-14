namespace RestaurantReservation.API.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeePositionDTO Position { get; set; }
    }
}
