using AutoMapper;
using RestaurantReservation.ApplicationLayer.DTO;
using RestaurantReservation.Db.EntityClass;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class EmployeeRestaurantViewProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EmployeeRestaurantView, EmployeeRestaurantViewDTO>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));
        }
    }
}