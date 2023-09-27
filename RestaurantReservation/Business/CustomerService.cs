using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class CustomerService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var customer = await _dbContext.Customers.FindAsync(customerId);

                Log.Information("Customer {CustomerId} retrieved successfully", customerId);
                return _mapper.Map<CustomerDTO>(customer);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching customer with ID: {CustomerId}", customerId);
                throw;
            }
        }

        public async Task CreateCustomerAsync(CustomerDTO customerDTO)
        {
            try
            {
                var newCustomer = _mapper.Map<Customer>(customerDTO);
                _dbContext.Customers.Add(newCustomer);
                await _dbContext.SaveChangesAsync();

                Log.Information("Customer {CustomerId} created successfully", newCustomer.customer_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating customer");
                throw;
            }
        }

        public async Task UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            try
            {
                var existingCustomer = await _dbContext.Customers.FindAsync(customerDTO.CustomerId);
                if (existingCustomer is not null)
                {
                    _mapper.Map(customerDTO, existingCustomer);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Customer {CustomerId} updated successfully", customerDTO.CustomerId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating customer with ID: {CustomerId}", customerDTO.CustomerId);
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
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting customer with ID: {CustomerId}", customerId);
                throw;
            }
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _dbContext.Customers.ToListAsync();
                var customerDTOs = _mapper.Map<List<CustomerDTO>>(customers);

                Log.Information("Retrieved all customers successfully");
                return customerDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all customers");
                throw;
            }
        }
    }

}