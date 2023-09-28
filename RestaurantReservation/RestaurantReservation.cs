using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.ApplicationLayer.Profile;
using RestaurantReservation.Business;
using RestaurantReservation.Db;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Reflection;

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
        public void ConfigureProfiles(IMapperConfigurationExpression configuration)
        {
            // Get all types that implement IProfile from the current assembly
            var profileTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(IProfile).IsAssignableFrom(type) && !type.IsInterface).
                Select(Activator.CreateInstance)
               .OfType<IProfile>();
            // Instantiate and configure each profile
            foreach (var profile in profileTypes)
            {
                profile.ConfigureProfile(configuration);
            }
        }
        public void MapperConfiguration()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                ConfigureProfiles(cfg);
            });

            this.mapper = new Mapper(mapperConfig);
        }
    }
}