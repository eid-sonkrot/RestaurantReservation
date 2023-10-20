using AutoMapper;
using RestaurantReservation.ApplicationLayer.DTO;
using RestaurantReservation.Db.EntityClass;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class MenuItemProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<MenuItem, MenuItemDTO>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.item_id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price));
        }
    }
}