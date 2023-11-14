using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.Domain.IRepository
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
