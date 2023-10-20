using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using RestaurantReservation.Db.EntityClass;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<EmployeeDomain> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(employeeId);

                return _mapper.Map<EmployeeDomain>(employee);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
        public async Task CreateEmployeeAsync(EmployeeDomain employee)
        {
            try
            {
                var employeeData = _mapper.Map<Employee>(employee);

                _dbContext.Employees.Add(employeeData);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating employee");
                throw;
            }
        }
        public async Task UpdateEmployeeAsync(EmployeeDomain employee)
        {
            try
            {
                var employeeData = _mapper.Map<Employee>(employee);

                _dbContext.Entry(employeeData).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating employee with ID: {EmployeeId}", employee.EmployeeId);
                throw;
            }
        }
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                var employeeData = await _dbContext.Employees.FindAsync(employeeId);

                if (employeeData is not null)
                {
                    _dbContext.Employees.Remove(employeeData);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
        public async Task<List<EmployeeDomain>> GetAllEmployeesAsync()
        {
            try
            {
                var employeeDataList = await _dbContext.Employees.ToListAsync();
                var employee = employeeDataList.Select(e => _mapper.Map<EmployeeDomain>(e)).ToList();

                return employee;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all employees");
                throw;
            }
        }
        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            try
            {
                var ordersData = await _dbContext.Orders
                    .Where(o => o.employee_id == employeeId)
                    .ToListAsync();

                if (ordersData.Any())
                {
                    var totalAmount = ordersData.Sum(o => o.total_amount);
                    var averageAmount = totalAmount / ordersData.Count;

                    return averageAmount;
                }
                else
                {
                    // Handle the case where the employee has no orders
                    return 0.0;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while calculating average order amount for employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
        public async Task<List<EmployeeDomain>> ListManagersAsync()
        {
            try
            {
                var managersData = await _dbContext.Employees
                    .Where(employee => employee.position == EmployeePosition.Manager)
                    .ToListAsync();

                return _mapper.Map<List<EmployeeDomain>>(managersData);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching managers");
                throw;
            }
        }
    }
}