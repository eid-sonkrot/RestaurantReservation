using AutoMapper;
using RestaurantReservation.ApplicationLayer.DTO;
using RestaurantReservation.Db.EntityClass;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class RestaurantProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.restaurant_id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phone_number));
        }
    }
}