using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid Phone number.")]
        public string Phone { get; set; }
    }
}