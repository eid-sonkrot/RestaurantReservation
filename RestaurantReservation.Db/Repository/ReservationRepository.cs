using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using RestaurantReservation.Db.EntityClass;
using Serilog;
namespace RestaurantReservation.Db.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ReservationDomain> GetReservationByIdAsync(int reservationId)
        {
            try
            {
                var reservationEntity = await _dbContext.Reservations.FindAsync(reservationId);

                return _mapper.Map<ReservationDomain>(reservationEntity);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting reservation by ID: {ReservationId}", reservationId);
                throw;
            }
        }
        public async Task CreateReservationAsync(ReservationDomain reservation)
        {
            try
            {
                var reservationEntity = _mapper.Map<Reservation>(reservation);

                _dbContext.Reservations.Add(reservationEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating reservation");
                throw;
            }
        }
        public async Task UpdateReservationAsync(ReservationDomain reservation)
        {
            try
            {
                var reservationEntity=_mapper.Map<Reservation>(reservation);
                var existingReservationEntity = await _dbContext.Reservations.FindAsync(reservationEntity.reservation_id);

                if (existingReservationEntity is null)
                {
                    _dbContext.Entry(existingReservationEntity).CurrentValues.SetValues(reservationEntity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating reservation with ID: {ReservationId}", reservation.ReservationId);
                throw;
            }
        }
        public async Task DeleteReservationAsync(int reservationId)
        {
            try
            {
                var reservationEntity = await _dbContext.Reservations.FindAsync(reservationId);

                if (reservationEntity is not null)
                {
                    _dbContext.Reservations.Remove(reservationEntity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting reservation with ID: {ReservationId}", reservationId);
                throw;
            }
        }
        public async Task<List<ReservationDomain>> GetAllReservationsAsync()
        {
            try
            {
                var reservationEntities = await _dbContext.Reservations.ToListAsync();

                return reservationEntities.Select(entity => _mapper.Map<ReservationDomain>(entity)).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting all reservations");
                throw;
            }
        }
        public async Task<List<ReservationDomain>> GetReservationsByCustomerAsync(int customerId)
        {
            try
            {
                var reservationEntities = await _dbContext.Reservations
                    .Where(r => r.customer_id == customerId)
                    .ToListAsync();

                return reservationEntities.Select(entity => _mapper.Map<ReservationDomain>(entity)).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching reservations for customer {CustomerId}", customerId);
                throw;
            }
        }
    }
}