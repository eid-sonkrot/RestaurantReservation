using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer.DTO;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class ReservationViewRepository : IReservationViewRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationViewRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<ReservationViewDomain>> GetReservationsWithDetailsAsync()
        {
            try
            {
                var reservationsWithDetails = await _dbContext.ReservationViews
                    .Include(r => r.Customer)
                    .Include(r => r.Restaurant)
                    .ToListAsync();

                return reservationsWithDetails.Select(r=>_mapper.Map<ReservationViewDomain>(r)).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching reservations view");
                throw;
            }
        }
    }
}