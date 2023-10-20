using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
{
    public interface ICustomerRepository
    {
        Task<CustomerDomain> GetCustomerByIdAsync(int customerId);
        Task CreateCustomerAsync(CustomerDomain customer);
        Task UpdateCustomerAsync(CustomerDomain customer);
        Task DeleteCustomerAsync(int customerId);
        Task<List<CustomerDomain>> GetAllCustomersAsync();
        Task<List<CustomerDomain>> FindCustomersWithLargePartiesAsync(int minPartySize);
    }
}