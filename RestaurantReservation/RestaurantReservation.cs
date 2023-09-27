using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Business;
using RestaurantReservation.Db;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace RestaurantReservation
{
    class RestaurantReservation
    {
        public RestaurantReservationDbContext restaurantReservationDbContext { get; set; }
        public Mapper mapper { get; set; }
        static async Task Main(string[] args)
        {
            var restaurantReservation = new RestaurantReservation();
        }
        public RestaurantReservation() 
        {
            LoggerConfiguration();
            MapperConfiguration();
        }
        public void LoggerConfiguration()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            Log.Logger= new LoggerConfiguration()
                        .WriteTo.File(Path.Combine(currentDirectory, "Information.log"),
                         restrictedToMinimumLevel: LogEventLevel.Information,
                         rollingInterval: RollingInterval.Day,
                         rollOnFileSizeLimit: true)
                        .WriteTo.File(Path.Combine(currentDirectory, "Error.log"),
                         restrictedToMinimumLevel: LogEventLevel.Error,
                         rollingInterval: RollingInterval.Day,
                         rollOnFileSizeLimit: true)
                         .CreateLogger();
        }
        public void MapperConfiguration()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                // Employee to EmployeeDTO mapping
                cfg.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.employee_id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.position.ToString()));
                // Customer to CustomerDTO mapping
                cfg.CreateMap<Customer, CustomerDTO>()
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.customer_id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone));
                // MenuItem to MenuItemDTO mapping
                cfg.CreateMap<MenuItem, MenuItemDTO>()
                    .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.item_id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price));
                // Order to OrderDTO mapping
                cfg.CreateMap<Order, OrderDTO>()
                    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.order_id))
                    .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.reservation_id))
                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.employee_id))
                    .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.order_date))
                    .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.total_amount));
                // OrderItem to OrderItemDTO mapping
                cfg.CreateMap<OrderItem, OrderItemDTO>()
                    .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.order_item_id))
                    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.order_id))
                    .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.item_id))
                    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.quantity));
                // Reservation to ReservationDTO mapping
                cfg.CreateMap<Reservation, ReservationDTO>()
                    .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.reservation_id))
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.customer_id))
                    .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.restaurant_id))
                    .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.table_id))
                    .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.reservation_date))
                    .ForMember(dest => dest.PartySize, opt => opt.MapFrom(src => src.party_size));
                // Restaurant to RestaurantDTO mapping
                cfg.CreateMap<Restaurant, RestaurantDTO>()
                    .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.restaurant_id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phone_number));
                // Table to TableDTO mapping
                cfg.CreateMap<Table, TableDTO>()
                    .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.table_id))
                    .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.restaurant_id))
                    .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.capacity));

            });

            this.mapper = new Mapper(mapperConfig);
        }
    }
}