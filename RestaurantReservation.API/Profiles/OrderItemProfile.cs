using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class OrderItemProfile:Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemDTO, OrderItemDomain>()
                .ForMember(dest => dest.OrderItemId, opt => opt.Ignore()); ;
            CreateMap<OrderItemDomain, OrderItemDTO>();
            CreateMap<OrderItem, OrderItemDomain>();
            CreateMap<OrderItemDomain, OrderItem>();
        }
    }
}