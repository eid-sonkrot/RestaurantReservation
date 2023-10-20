using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
{
    public interface IEmployeeRestaurantViewRepository
    {
        List<EmployeeRestaurantViewDomain> GetAllEmployeeRestaurantViews();
    }
}