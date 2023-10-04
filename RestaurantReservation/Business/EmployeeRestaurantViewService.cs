using AutoMapper;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;

namespace RestaurantReservation.Business
{
    public class EmployeeRestaurantViewService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRestaurantViewService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<EmployeeRestaurantViewDTO> GetAllEmployeeRestaurantViews()
        {
            var views = _dbContext.EmployeeRestaurantViews.ToList();
            return _mapper.Map<List<EmployeeRestaurantViewDTO>>(views);
        }

    }

}
