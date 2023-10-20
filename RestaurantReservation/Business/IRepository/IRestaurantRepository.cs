using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
{
    public interface IRestaurantRepository
    {
        Task<RestaurantDomain> GetRestaurantByIdAsync(int restaurantId);
        Task CreateRestaurantAsync(RestaurantDomain restaurant);
        Task UpdateRestaurantAsync(RestaurantDomain restaurant);
        Task DeleteRestaurantAsync(int restaurantId);
        Task<List<RestaurantDomain>> GetAllRestaurantsAsync();
        Task<double> CalculateTotalRevenue(int restaurantId);
    }
}