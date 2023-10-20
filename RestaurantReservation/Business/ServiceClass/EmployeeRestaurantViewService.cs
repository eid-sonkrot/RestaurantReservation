using AutoMapper;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class EmployeeRestaurantViewService
    {
        private readonly IEmployeeRestaurantViewRepository _employeeRestaurantViewRepository;
        private readonly IMapper _mapper;

        public EmployeeRestaurantViewService(IEmployeeRestaurantViewRepository employeeRestaurantViewRepository, IMapper mapper)
        {
            _employeeRestaurantViewRepository = employeeRestaurantViewRepository;
            _mapper = mapper;
        }
        public List<EmployeeRestaurantViewDomain> GetAllEmployeeRestaurantViews()
        {
            try
            {
                var views = _employeeRestaurantViewRepository.GetAllEmployeeRestaurantViews();

                return _mapper.Map<List<EmployeeRestaurantViewDomain>>(views);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while retrieving all employee restaurant views");
                throw;
            }
        }
    }
}
