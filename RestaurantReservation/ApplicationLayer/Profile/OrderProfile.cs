using AutoMapper;
using RestaurantReservation.ApplicationLayer.DTO;
using RestaurantReservation.Db.EntityClass;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public class OrderProfile : IProfile
    {
        public void ConfigureProfile(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.order_id))
                .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.reservation_id))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.employee_id))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.order_date))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.total_amount));
        }
    }
}