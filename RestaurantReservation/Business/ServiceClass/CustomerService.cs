using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository=customerRepository;
        }
        public async Task<CustomerDomain> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(customerId);

                Log.Information("Customer {CustomerId} retrieved successfully", customerId);
                return customer;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching customer with ID: {CustomerId}", customerId);
                throw;
            }
        }
        public async Task CreateCustomerAsync(CustomerDomain customer)
        {
            try
            {
                 await _customerRepository.CreateCustomerAsync(customer);
                Log.Information("Customer {CustomerId} created successfully", customer.CustomerId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating customer");
                throw;
            }
        }
        public async Task UpdateCustomerAsync(CustomerDomain customer)
        {
            try
            {
                await _customerRepository.UpdateCustomerAsync(customer);
                Log.Information("Customer {CustomerId} updated successfully", customer.CustomerId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating customer with ID: {CustomerId}", customer.CustomerId);
                throw;
            }
        }
        public async Task DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerRepository.DeleteCustomerAsync(customerId);  
                Log.Information("Customer {CustomerId} deleted successfully", customerId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting customer with ID: {CustomerId}", customerId);
                throw;
            }
        }
        public async Task<List<CustomerDomain>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomersAsync();
                
                Log.Information("Retrieved all customers successfully");
                return customers;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all customers");
                throw;
            }
        }
        public async Task<List<CustomerDomain>> FindCustomersWithLargePartiesAsync(int minPartySize)
        {
            try
            {
                var customers = await _customerRepository.FindCustomersWithLargePartiesAsync(minPartySize);

                Log.Information("Retrieved all customers with larger party size than {minPartySize}", minPartySize);
                return customers;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all customers with larger party size than {minPartySize}", minPartySize);
                throw;
            }
        }
    }
}