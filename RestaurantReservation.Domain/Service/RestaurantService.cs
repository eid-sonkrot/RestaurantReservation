using RestaurantReservation.Domain.Domain;
using RestaurantReservation.Domain.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class RestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository  restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<RestaurantDomain> GetRestaurantByIdAsync(int restaurantId)
        {
            try
            {
                var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(restaurantId);

                Log.Information("Restaurant {RestaurantId} retrieved successfully", restaurantId);
                return restaurant;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching restaurant with ID: {RestaurantId}", restaurantId);
                throw;
            }
        }
        public async Task CreateRestaurantAsync(RestaurantDomain restaurantDomain)
        {
            try
            {
                await _restaurantRepository.CreateRestaurantAsync(restaurantDomain);

                Log.Information("Restaurant {RestaurantId} created successfully", restaurantDomain.RestaurantId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating restaurant");
                throw;
            }
        }
        public async Task UpdateRestaurantAsync(RestaurantDomain restaurantDomain)
        {
            try
            {
                await _restaurantRepository.UpdateRestaurantAsync(restaurantDomain);

                Log.Information("Restaurant {RestaurantId} updated successfully", restaurantDomain.RestaurantId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating restaurant with ID: {RestaurantId}", restaurantDomain.RestaurantId);
                throw;
            }
        }
        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            try
            {
                await _restaurantRepository.DeleteRestaurantAsync(restaurantId);

                Log.Information("Restaurant {RestaurantId} deleted successfully", restaurantId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting restaurant with ID: {RestaurantId}", restaurantId);
                throw;
            }
        }
        public async Task<List<RestaurantDomain>> GetAllRestaurantsAsync()
        {
            try
            {
                Log.Information("Retrieved all restaurants successfully");
                return await _restaurantRepository.GetAllRestaurantsAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all restaurants");
                throw;
            }
        }
        public async Task<double> CalculateTotalRevenue(int restaurantId)
        {
            try
            {
                var totalRevenue = await _restaurantRepository.CalculateTotalRevenue(restaurantId);

                Log.Information(@"Total Revenue of restaurant {restaurantId} is {totalRevenue} ", restaurantId, totalRevenue);
                return totalRevenue;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while get Revenue of restaurant");
                throw;
            }
        }
    }
}