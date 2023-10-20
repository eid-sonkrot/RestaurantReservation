using AutoMapper;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using RestaurantReservation.Db.EntityClass;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class EmployeeRestaurantViewRepository : IEmployeeRestaurantViewRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRestaurantViewRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<EmployeeRestaurantViewDomain> GetAllEmployeeRestaurantViews()
        {
            try
            {
                var views = _dbContext.EmployeeRestaurantViews.ToList();

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