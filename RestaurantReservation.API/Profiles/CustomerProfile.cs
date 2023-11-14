using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, CustomerDomain>()
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore()); 
            CreateMap<CustomerDomain, CustomerDTO>(); 
            CreateMap<Customer, CustomerDomain>(); 
            CreateMap<CustomerDomain, Customer>();
        }
    }
}