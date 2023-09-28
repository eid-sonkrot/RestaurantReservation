using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class ReservationService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ReservationDTO> GetReservationByIdAsync(int reservationId)
        {
            try
            {
                var reservation = await _dbContext.Reservations.FindAsync(reservationId);

                Log.Information("Reservation {ReservationId} retrieved successfully", reservationId);
                return _mapper.Map<ReservationDTO>(reservation);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching reservation with ID: {ReservationId}", reservationId);
                throw;
            }
        }
        public async Task CreateReservationAsync(ReservationDTO reservationDTO)
        {
            try
            {
                var newReservation = _mapper.Map<Reservation>(reservationDTO);
                _dbContext.Reservations.Add(newReservation);
                await _dbContext.SaveChangesAsync();

                Log.Information("Reservation {ReservationId} created successfully", newReservation.reservation_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating reservation");
                throw;
            }
        }
        public async Task UpdateReservationAsync(ReservationDTO reservationDTO)
        {
            try
            {
                var existingReservation = await _dbContext.Reservations.FindAsync(reservationDTO.ReservationId);

                if (existingReservation is not null)
                {
                    _mapper.Map(reservationDTO, existingReservation);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Reservation {ReservationId} updated successfully", reservationDTO.ReservationId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating reservation with ID: {ReservationId}", reservationDTO.ReservationId);
                throw;
            }
        }
        public async Task DeleteReservationAsync(int reservationId)
        {
            try
            {
                var reservation = await _dbContext.Reservations.FindAsync(reservationId);

                if (reservation is not null)
                {
                    _dbContext.Reservations.Remove(reservation);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Reservation {ReservationId} deleted successfully", reservationId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting reservation with ID: {ReservationId}", reservationId);
                throw;
            }
        }
        public async Task<List<ReservationDTO>> GetAllReservationsAsync()
        {
            try
            {
                var reservations = await _dbContext.Reservations.ToListAsync();
                var reservationDTOs = _mapper.Map<List<ReservationDTO>>(reservations);

                Log.Information("Retrieved all reservations successfully");
                return reservationDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all reservations");
                throw;
            }
        }
        public async Task<List<ReservationDTO>> GetReservationsByCustomerAsync(int customerId)
        {
            try
            {
                var reservations = await _dbContext.Reservations
                    .Where(r => r.customer_id == customerId)
                    .ToListAsync();

                return _mapper.Map<List<ReservationDTO>>(reservations);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching reservations for customer {CustomerId}", customerId);
                throw;
            }
        }
    }
}