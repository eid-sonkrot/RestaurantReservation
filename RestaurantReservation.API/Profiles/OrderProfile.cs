using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, OrderDomain>()
                .ForMember(dest => dest.OrderId, opt => opt.Ignore());
            CreateMap<OrderDomain, OrderDTO>();
            CreateMap<Order, OrderDomain>();
            CreateMap<OrderDomain, Order>();
        }
    }
}