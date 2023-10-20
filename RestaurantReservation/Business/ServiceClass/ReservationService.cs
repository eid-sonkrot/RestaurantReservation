using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationDomain> GetReservationByIdAsync(int reservationId)
        {
            try
            {
                var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);

                return reservation;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching reservation with ID: {ReservationId}", reservationId);
                throw;
            }
        }
        public async Task CreateReservationAsync(ReservationDomain reservation)
        {
            try
            {
                await _reservationRepository.CreateReservationAsync(reservation);
                Log.Information("Reservation {ReservationId} created successfully", reservation.ReservationId);
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
                await _reservationRepository.UpdateReservationAsync(reservation);
                Log.Information("Reservation {ReservationId} updated successfully", reservation.ReservationId);
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
                await _reservationRepository.DeleteReservationAsync(reservationId);
                Log.Information("Reservation {ReservationId} deleted successfully", reservationId);
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
                var reservations = await _reservationRepository.GetAllReservationsAsync();

                return reservations;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all reservations");
                throw;
            }
        }
        public async Task<List<ReservationDomain>> GetReservationsByCustomerAsync(int customerId)
        {
            try
            {
                var reservations = await _reservationRepository.GetReservationsByCustomerAsync(customerId);

                return reservations;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching reservations for customer {CustomerId}", customerId);
                throw;
            }
        }
    }
}