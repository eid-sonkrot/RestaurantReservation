namespace RestaurantReservation.API
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username);
    }
}