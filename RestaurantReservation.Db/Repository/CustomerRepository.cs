using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Domain;
using RestaurantReservation.Domain.IRepository;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CustomerDomain> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var customer = await _dbContext.Customers.FindAsync(customerId);
                var customerDomain = _mapper.Map<CustomerDomain>(customer);

                return customerDomain;
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
                var customerEntity = _mapper.Map<Customer>(customer);

                _dbContext.Customers.Add(customerEntity);
                await _dbContext.SaveChangesAsync();

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
                var customerEntity = _mapper.Map<Customer>(customer);
                var existingCustomer = await _dbContext.Customers.FindAsync(customerEntity.CustomerId);


                _dbContext.Customers.Remove(existingCustomer);
                _dbContext.Customers.Add(customerEntity);
                await _dbContext.SaveChangesAsync();
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
                var customer = await _dbContext.Customers.FindAsync(customerId);
                
                if (customer is not null)
                {
                    _dbContext.Customers.Remove(customer);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Customer {CustomerId} deleted successfully", customerId);
                }
                else
                {
                    throw new ArgumentNullException();
                }
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
                var customers = await _dbContext.Customers.ToListAsync();
                var customersDomain = customers.Select(c => _mapper.Map<CustomerDomain>(c)).ToList();

                return customersDomain;
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
                var customers =  await _dbContext.FindCustomersWithLargePartiesAsync(minPartySize);
                var customersDomain = customers.Select(c => _mapper.Map<CustomerDomain>(c)).ToList();

                return customersDomain;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching customers with a party size larger than {minPartySize}", minPartySize);
                throw;
            }
        }
    }
}