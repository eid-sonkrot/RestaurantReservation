using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class ReservationProfile: Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDTO, ReservationDomain>()
                .ForMember(dest => dest.ReservationId, opt => opt.Ignore());
            CreateMap<ReservationDomain, ReservationDTO>();
            CreateMap<Reservation, ReservationDomain>();
            CreateMap<ReservationDomain, Reservation>();
        }
    }
}