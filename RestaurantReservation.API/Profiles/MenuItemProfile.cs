using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class MenuItemProfile:Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItemDTO, MenuItemDomain>()
                .ForMember(dest => dest.ItemId, opt => opt.Ignore()); 
            CreateMap<MenuItemDomain, MenuItemDTO>();
            CreateMap<MenuItem, MenuItemDomain>();
            CreateMap<MenuItemDomain, MenuItem>();
        }
    }
}