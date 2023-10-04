using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class ReservationViewService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationViewService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<ReservationViewDTO>> GetReservationsWithDetailsAsync()
        {
            try
            {
                var reservationsWithDetails = await _dbContext.ReservationViews
                    .Include(r => r.Customer)
                    .Include(r => r.Restaurant)
                    .ToListAsync();

                return _mapper.Map<List<ReservationViewDTO>>(reservationsWithDetails);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching reservations viwe}");
                throw;
            }
        }
    }
}
