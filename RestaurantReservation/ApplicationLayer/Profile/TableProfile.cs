using AutoMapper;
using RestaurantReservation.Db;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class TableProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Table, TableDTO>()
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.table_id))
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.restaurant_id))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.capacity));
        }
    }
}