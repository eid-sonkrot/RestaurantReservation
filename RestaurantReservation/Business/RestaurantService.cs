using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class RestaurantService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<RestaurantDTO> GetRestaurantByIdAsync(int restaurantId)
        {
            try
            {
                var restaurant = await _dbContext.Restaurants.FindAsync(restaurantId);

                Log.Information("Restaurant {RestaurantId} retrieved successfully", restaurantId);
                return _mapper.Map<RestaurantDTO>(restaurant);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching restaurant with ID: {RestaurantId}", restaurantId);
                throw;
            }
        }
        public async Task CreateRestaurantAsync(RestaurantDTO restaurantDTO)
        {
            try
            {
                var newRestaurant = _mapper.Map<Restaurant>(restaurantDTO);
                _dbContext.Restaurants.Add(newRestaurant);
                await _dbContext.SaveChangesAsync();

                Log.Information("Restaurant {RestaurantId} created successfully", newRestaurant.restaurant_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating restaurant");
                throw;
            }
        }
        public async Task UpdateRestaurantAsync(RestaurantDTO restaurantDTO)
        {
            try
            {
                var existingRestaurant = await _dbContext.Restaurants.FindAsync(restaurantDTO.RestaurantId);

                if (existingRestaurant is not null)
                {
                    _mapper.Map(restaurantDTO, existingRestaurant);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Restaurant {RestaurantId} updated successfully", restaurantDTO.RestaurantId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating restaurant with ID: {RestaurantId}", restaurantDTO.RestaurantId);
                throw;
            }
        }
        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            try
            {
                var restaurant = await _dbContext.Restaurants.FindAsync(restaurantId);

                if (restaurant is not null)
                {
                    _dbContext.Restaurants.Remove(restaurant);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Restaurant {RestaurantId} deleted successfully", restaurantId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting restaurant with ID: {RestaurantId}", restaurantId);
                throw;
            }
        }
        public async Task<List<RestaurantDTO>> GetAllRestaurantsAsync()
        {
            try
            {
                var restaurants = await _dbContext.Restaurants.ToListAsync();
                var restaurantDTOs = _mapper.Map<List<RestaurantDTO>>(restaurants);

                Log.Information("Retrieved all restaurants successfully");
                return restaurantDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all restaurants");
                throw;
            }
        }
    }
}