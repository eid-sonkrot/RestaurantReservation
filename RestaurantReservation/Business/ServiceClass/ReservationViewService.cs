using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class ReservationViewService
    {
        private readonly IReservationViewRepository _reservationViewRepository;

        public ReservationViewService(IReservationViewRepository reservationViewRepository)
        {
            _reservationViewRepository = reservationViewRepository;
        }

        public async Task<List<ReservationViewDomain>> GetReservationsWithDetailsAsync()
        {
            try
            {
                var reservationsWithDetails = await _reservationViewRepository.GetReservationsWithDetailsAsync();

                return reservationsWithDetails;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching reservations view");
                throw;
            }
        }
    }
}
