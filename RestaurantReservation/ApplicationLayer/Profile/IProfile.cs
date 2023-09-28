using AutoMapper;

namespace RestaurantReservation.ApplicationLayer.Profile
{
    public interface IProfile
    {
        void ConfigureProfile(IMapperConfigurationExpression configuration);
    }
}
