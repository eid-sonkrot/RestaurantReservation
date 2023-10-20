using AutoMapper;
using RestaurantReservation.ApplicationLayer.DTO;
using RestaurantReservation.Db.EntityClass;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class EmployeeProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.employee_id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.position.ToString()));
        }
    }
}