using AutoMapper;
using RestaurantReservation.Db;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class ReservationProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Reservation, ReservationDTO>()
                .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.reservation_id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.customer_id))
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.restaurant_id))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.table_id))
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.reservation_date))
                .ForMember(dest => dest.PartySize, opt => opt.MapFrom(src => src.party_size));
        }
    }
}