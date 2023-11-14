using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.Domain.IRepository
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