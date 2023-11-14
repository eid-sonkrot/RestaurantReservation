using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, EmployeeDomain>()
                .ForMember(dest => dest.EmployeeId, opt => opt.Ignore());
            CreateMap<EmployeeDomain, EmployeeDTO>();
            CreateMap<Employee, EmployeeDomain>();
            CreateMap<EmployeeDomain, Employee>();
        }
    }
}