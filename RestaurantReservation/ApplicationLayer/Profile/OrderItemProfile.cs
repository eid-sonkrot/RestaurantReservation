using AutoMapper;
using RestaurantReservation.Db;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class OrderItemProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.order_item_id))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.order_id))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.item_id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.quantity));
        }
    }
}