using AutoMapper;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Profiles
{
    public class TableProfile:Profile
    {
        public TableProfile()
        {
            CreateMap<TableDTO, TableDomain>()
                .ForMember(dest => dest.TableId, opt => opt.Ignore());
            CreateMap<TableDomain, TableDTO>();
            CreateMap<Table, TableDomain>();
            CreateMap<TableDomain, Table>();
        }
    }
}