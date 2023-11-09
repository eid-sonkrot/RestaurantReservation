using System.ComponentModel.DataAnnotations;
namespace RestaurantReservation.Db
{
    public enum EmployeePosition
    {
        [Display(Name = "Manager")]
        Manager,
        [Display(Name = "Supervisor")]
        Supervisor,
        [Display(Name = "Staff")]
        Staff,
        [Display(Name = "Intern")]
        Intern,
    }
}