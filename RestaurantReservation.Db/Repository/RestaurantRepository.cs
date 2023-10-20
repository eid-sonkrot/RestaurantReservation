using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using RestaurantReservation.Db.EntityClass;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<RestaurantDomain> GetRestaurantByIdAsync(int restaurantId)
        {
            try
            {
                var restaurant = await _dbContext.Restaurants.FindAsync(restaurantId);
                return _mapper.Map<RestaurantDomain>(restaurant);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching restaurant with ID: {RestaurantId}", restaurantId);
                throw;
            }
        }
        public async Task CreateRestaurantAsync(RestaurantDomain restaurant)
        {
            try
            {
                var newRestaurant = _mapper.Map<Restaurant>(restaurant);

                _dbContext.Restaurants.Add(newRestaurant);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating restaurant");
                throw;
            }
        }
        public async Task UpdateRestaurantAsync(RestaurantDomain restaurant)
        {
            try
            {
                var restaurantEntity = _mapper.Map<Restaurant>(restaurant);
                var existingRestaurantEntity = await _dbContext.Reservations.FindAsync(restaurantEntity.restaurant_id);

                if (existingRestaurantEntity is not null)
                {
                    _dbContext.Entry(existingRestaurantEntity).CurrentValues.SetValues(restaurantEntity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating restaurant with ID: {RestaurantId}", restaurant.RestaurantId);
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
                }
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
                var restaurants = await _dbContext.Restaurants.ToListAsync();

                return restaurants.Select(r=> _mapper.Map<RestaurantDomain>(r)).ToList();
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
                var totalRevenue = await _dbContext.CalculateTotalRevenue(restaurantId);

                return totalRevenue;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting revenue of restaurant");
                throw;
            }
        }
    }
}