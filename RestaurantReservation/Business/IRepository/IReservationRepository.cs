using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
{
    public interface IReservationRepository
    {
        Task<ReservationDomain> GetReservationByIdAsync(int reservationId);
        Task CreateReservationAsync(ReservationDomain reservation);
        Task UpdateReservationAsync(ReservationDomain reservation);
        Task DeleteReservationAsync(int reservationId);
        Task<List<ReservationDomain>> GetAllReservationsAsync();
        Task<List<ReservationDomain>> GetReservationsByCustomerAsync(int customerId);
    }
}