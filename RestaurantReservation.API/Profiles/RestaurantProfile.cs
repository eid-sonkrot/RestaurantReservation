using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class RestaurantProfile:Profile
    {
        public RestaurantProfile()
        {
            CreateMap<RestaurantDTO, RestaurantDomain>()
                .ForMember(dest => dest.RestaurantId, opt => opt.Ignore());
            CreateMap<RestaurantDomain, RestaurantDTO>();
            CreateMap<Restaurant, RestaurantDomain>();
            CreateMap<RestaurantDomain, Restaurant>();
        }
    }
}