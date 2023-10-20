using AutoMapper;
using RestaurantReservation.ApplicationLayer.DTO;
using RestaurantReservation.Db.EntityClass;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class ReservationViewProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ReservationView, ReservationViewDTO>()
                .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.RestaurantId))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));
        }
    }
}