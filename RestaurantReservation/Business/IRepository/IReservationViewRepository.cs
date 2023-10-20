using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
{
    public interface IReservationViewRepository
    {
        Task<List<ReservationViewDomain>> GetReservationsWithDetailsAsync();
    }
}